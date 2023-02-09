namespace MyFirstFSharpWebApi.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging

[<ApiController>]
[<Route("[controller]")>]
type HelloWorldController(logger: ILogger<HelloWorldController>) =
    inherit ControllerBase()

    [<HttpGet>]

    let makeLowerCase (s: string) = s.ToLower()

    let toLowerIfStartsWithVowel (word: string) =
        let isVowel (c: char) =
            match c with
            | 'a'
            | 'e'
            | 'i'
            | 'o'
            | 'u'
            | 'A'
            | 'E'
            | 'I'
            | 'O'
            | 'U' -> true
            | _ -> false

        if isVowel word[0] then makeLowerCase (word) else word

    member this.Get() =
        let values = [| "Hello"; "World"; "First F#/ASP.NET Core web API!" |]
        ActionResult<string[]>(values)

    [<HttpGet>]
    member this.Get(word: string) =
        let result = toLowerIfStartsWithVowel (word)
        ActionResult<string>(result)
