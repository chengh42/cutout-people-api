open Fake.Core
open Fake.IO

open Helpers

initializeContext()

let srcPath = Path.getFullName "src"
let docsPath = Path.getFullName "docs"
let publishPath = Path.getFullName "publish"

Target.create "Clean" (fun _ ->
    Shell.cleanDir publishPath
    run dotnet "fable clean --yes" docsPath // Delete *.fs.js files created by Fable
)

Target.create "InstallNpm" (fun _ -> run npm "install" ".")

Target.create "Bundle" (fun _ ->
    run dotnet "fable -o output -s --run webpack -p" docsPath
)

Target.create "Run" (fun _ ->
    run dotnet "run" srcPath
)

Target.create "Docs" (fun _ ->
    run dotnet "fable watch -o output -s --run webpack-dev-server" docsPath
)

Target.create "Format" (fun _ ->
    run dotnet "fantomas . -r" "src"
)

open Fake.Core.TargetOperators

let dependencies = [
    "Clean"
        ==> "InstallNpm"
        ==> "Bundle"

    "Clean"
        ==> "InstallNpm"
        ==> "Docs"
]

[<EntryPoint>]
let main args = runOrDefault args