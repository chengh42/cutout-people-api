module Index

open Elmish
open Fable.Remoting.Client

type Model = { Input: string }

type Msg =
    | SetInput of string

let init () : Model * Cmd<Msg> =
    let model = { Input = "" }
    let cmd = Cmd.none

    model, cmd

let update (msg: Msg) (model: Model) : Model * Cmd<Msg> =
    match msg with
    | SetInput value -> { model with Input = value }, Cmd.none

open Feliz
open Feliz.Bulma

let view (model: Model) (dispatch: Msg -> unit) =
    Bulma.hero [
        hero.isFullHeight
        prop.children [
            Bulma.title.h3 "Cutout People"
        ]
    ]
