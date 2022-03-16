module Program

open System
open System.Threading.Tasks
open GraphQL
open GraphQL.Types
open GraphQL.SystemTextJson

type Hello = { Hello: string }

[<EntryPoint>]
let main (args: string []) =
    let schema = Schema.For (@"
            type Query {
                hello: String
            }
        ")
    let json =
        schema.ExecuteAsync(fun opts ->
            opts.Root <- { Hello = "Hello World" }
            opts.Query <- "{ hello }")
        |> Async.AwaitTask
        |> Async.RunSynchronously

    Console.WriteLine(json)

    0