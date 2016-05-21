namespace Fuse
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import
open Fable.Import.JS

type [<AbstractClass; Import("*","Request")>] Request(input: U2<string, Request>, ?init: RequestInit) =
    inherit Body()

and RequestInit =
    abstract ``method``: string option with get, set
    abstract headers: U2<HeaderInit, obj> option with get, set
    abstract body: BodyInit option with get, set
    abstract mode: RequestMode option with get, set
    abstract credentials: RequestCredentials option with get, set
    abstract cache: RequestCache option with get, set

and [<StringEnum>] RequestContext =
    | Audio | Beacon | Cspreport | Download | Embed | Eventsource | Favicon | Fetch | Font 
    | Form | Frame | Hyperlink | Iframe | Image | Imageset | Import | Internal | Location 
    | Manifest | Object | Ping | Plugin | Prefetch | Script | Serviceworker | Sharedworker 
    | Subresource | Style | Track | Video | Worker | Xmlhttprequest | Xslt

and [<StringEnum>] RequestMode =
    | [<CompiledName("same-origin")>]Sameorigin | [<CompiledName("no-cors")>]Nocors | Cors

and [<StringEnum>] RequestCredentials =
    Omit | [<CompiledName("same-origin")>]Sameorigin | Include

and [<StringEnum>] RequestCache =
    | Default
    | [<CompiledName("no-store")>]Nostore 
    | Reload
    | [<CompiledName("no-cache")>]Nocache
    | [<CompiledName("force-cache")>]Forcecache
    | [<CompiledName("only-if-cached")>]Onlyifcached

and [<Import("*","Headers")>] Headers() =
    class end

and [<AbstractClass; Import("*","Body")>] Body() =
    abstract json<'T> : unit -> Promise<'T>

and [<AbstractClass; Import("*","Response")>] Response(?body: BodyInit, ?init: ResponseInit) =
    inherit Body()


and [<StringEnum>] ResponseType =
    | Basic | Cors | Default | Error | Opaque

and ResponseInit =
    abstract status: float with get, set
    abstract statusText: string option with get, set
    abstract headers: HeaderInit option with get, set

and HeaderInit =
    U2<Headers, ResizeArray<string>>

and BodyInit =
    (*U3<Blob, FormData,*) string(*>*)

and RequestInfo =
    U2<Request, string>

and Window =
    abstract fetch: url: U2<string, Request> * ?init: RequestInit -> Promise<Response>

[<AutoOpen>]
module Globals =
    [<Global>]
    let fetch(url: string): Promise<Request> = failwith "JS only"

    module Promise =
        let inline success (a : 'T -> 'R) (pr : Promise<'T>) : Promise<'R> =
            pr?``then`` $ a |> unbox
    
        let inline bind (a : 'T -> Promise<'R>) (pr : Promise<'T>) : Promise<'R> =
            pr?bind $ a |> unbox
    
        //catch Func<obj, U2<'T, JS.PromiseLike<'T>>>> -> JS.Promise<'T>
        //catch Func<obj, Unit>> -> JS.Promise<'T> 
        let fail (a : obj -> 'T)  (pr : Promise<'T>) : Promise<'T> =
            pr.catch (unbox<Func<obj, U2<'T, JS.PromiseLike<'T>>>> a)
            
        //then Func<'T, U2<'R, JS.PromiseLike<'R>>>> * Func<obj, U2<'R, JS.PromiseLike<'R>>>> -> 'R
        //then Func<'T, U2<'R, JS.PromiseLike<'R>>>> * <Func<obj, Unit>> onrejected) -> 'R
        let either a  (b: Func<obj, U2<'R, JS.PromiseLike<'R>>>) (pr : Promise<'T>) : Promise<'R> =
            pr.``then``(a, b)
            //pr?``then`` $ (a, b) |> unbox
    
        let lift<'T> (a : 'T) : Promise<'T> =
            Promise.resolve(U2.Case1 a)
        
        type PromiseBuilder() =
            member inline x.Bind(m,f) = success f m
            member inline x.Return(a) = lift a
            member inline x.ReturnFrom(a) = a
            member inline x.Zero() = Promise.resolve()

[<AutoOpen>]
module PromiseBuilderImp =
    let promise = Globals.Promise.PromiseBuilder()

