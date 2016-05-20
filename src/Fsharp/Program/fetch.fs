namespace Fuse
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<Import("*","Request")>] Request(input: U2<string, Request>, ?init: RequestInit) =
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

and [<Import("*","Body")>] Body() =
    class end

and [<Import("*","Response")>] Response(?body: BodyInit, ?init: ResponseInit) =
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
    U3<Blob, FormData, string>

and RequestInfo =
    U2<Request, string>

and Window =
    abstract fetch: url: U2<string, Request> * ?init: RequestInit -> Promise<Response>

type Globals =
    [<Global>] static member fetch with get(): obj = failwith "JS only" and set(v: obj): unit = failwith "JS only"


