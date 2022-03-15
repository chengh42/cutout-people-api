module Index

open Elmish
open Fable.Remoting.Client

type Todo = { Id: System.Guid; Description: string }

type Model = { Todos: Todo list; Input: string }

type Msg =
    | SetInput of string

let init () : Model * Cmd<Msg> =
    let model = { Todos = []; Input = "" }

    model, Cmd.none

let update (msg: Msg) (model: Model) : Model * Cmd<Msg> =
    match msg with
    | SetInput value -> { model with Input = value }, Cmd.none

open Feliz
open Feliz.Bulma

let view (model: Model) (dispatch: Msg -> unit) =
    Bulma.hero [
        hero.isFullHeight
        color.isPrimary
        prop.children [
            Bulma.text.p "Cutout people"
        ]
    ]
