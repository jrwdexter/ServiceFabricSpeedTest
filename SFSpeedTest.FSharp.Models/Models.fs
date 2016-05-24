namespace SFSpeedTest.FSharp.Models
open System
open System.Runtime.Serialization

type EnumOne =
    | One = 1
    | Two = 2
    | Three = 3

type EnumTwo =
    | One = 1
    | Two = 2
    | Four = 4
    | Six = 6
    | Seven = 7

type EnumThree =
    | One = 1
    | Two = 2
    | Three = 3

[<DataContract>]
[<CLIMutable>]
type Person = {
    [<DataMember>] FirstName : string
    [<DataMember>] LastName: string
    [<DataMember>] Email: string
    [<DataMember>] PhoneNumber: string
}

[<DataContract>]
[<CLIMutable>]
type ListItem = {
     [<DataMember>] Name : string
     [<DataMember>] ETag : string
     [<DataMember>] Url : string
}

[<DataContract>]
[<CLIMutable>]
type Relation = {
    [<DataMember>] Id : Guid
    [<DataMember>] ItemId : Guid
    [<DataMember>] Number : decimal
    [<DataMember>] EOne : EnumOne
    [<DataMember>] ETwo : EnumTwo
    [<DataMember>] EThree : EnumThree
}

[<DataContract>]
[<CLIMutable>]
type Item = {
    [<DataMember>] Id : Guid
    [<DataMember>] Name: string
    [<DataMember>] Type : string
    [<DataMember>] Summary: string
    [<DataMember>] Description: string
    [<DataMember>] Relations: Relation[]
    [<DataMember>] ParentId: Guid
    [<DataMember>] ListItem: ListItem option
    [<DataMember>] AllListItems: ListItem array
    [<DataMember>] IsDeleted: bool
}

type Defaults() = 
    static member Contact = 
        {
            FirstName = "John"
            LastName = "John"
            Email = "john@example.com"
            PhoneNumber = "123 123 1234"
        }
    static member ListItem =
        {
            Name = "Item"
            ETag = "tag"
            Url = "http://example.com"
        }

    static member CreateListItem () =
        {
            Id = Guid.NewGuid()
            ItemId = Guid.Empty
            Number = 1.0M
            EOne = EnumOne.Three
            ETwo = EnumTwo.One
            EThree = EnumThree.Three
        }

    static member CreateItem () =
        {
            Id = Guid.NewGuid()
            Name= "Name"
            Type = "Item Type"
            Summary= "An item"
            Description= "A description"
            Relations= [1..4] |> Seq.map (fun _ -> Defaults.CreateListItem()) |> Seq.toArray
            ParentId= Guid.NewGuid()
            ListItem= Defaults.ListItem |> Some
            AllListItems= [1..3] |> Seq.map (fun _ -> Defaults.ListItem) |> Seq.toArray
            IsDeleted= false
        }