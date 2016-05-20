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

        //let fail (a : obj -> 'T)  (pr : Promise<'T>) : Promise<'T> =
        //    pr.catch(unbox a)

        let either (a : 'T -> 'R) (b : obj -> 'R)  (pr : Promise<'T>) : Promise<'R> =
            pr?``then`` $ (a, b) |> unbox

        let lift<'T> (a : 'T) : Promise<'T> =
            Promise.resolve(U2.Case1 a)

        //let toPromise (a : Thenable<'T>) = a |> unbox<Promise<'T>>

        //let toThenable (a : Promise<'T>) = a |> unbox<Thenable<'T>>
        
type PromiseBuilder() =
    member inline x.Bind(m,f) = Globals.Promise.success f m
    member inline x.Return(a) = Globals.Promise.lift a
    member inline x.ReturnFrom(a) = a
    member inline x.Zero() = Promise.resolve()

[<AutoOpen>]
module PromiseBuilderImp =
    let promise = PromiseBuilder()

