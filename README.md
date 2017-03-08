**Todo App Api** 

This api is the back end for a simple todo web app.

The following endpoints will be provided



- **GET** /api/lists

  - provides a list of the todo lists (Id,Name)
  - link to POST a new list

- **POST** /api/lists -> { Name : <new list name>}

  - creates a new list with the given name
  - returns a link to the new list

- **GET** /api/lists/ca0a7253-3ef3-4cc4-b868-0214e8d46bbd

  - provides the information about a list { Id, Name, CreatedDate, OwnerId }
  - link to DELETE the list
  - link to PUT a new name to the list
  - link to GET the items of the list

- **DELETE** /api/lists/ca0a7253-3ef3-4cc4-b868-0214e8d46bbd

  - removes a list

- **PUT** /api/lists/ca0a7253-3ef3-4cc4-b868-0214e8d46bbd -> { Name : <new list name>}

  - updates the list name

- **GET** /api/lists/ca0a7253-3ef3-4cc4-b868-0214e8d46bbd/items

  - provides the list of items
  - link to POST a new item

- **POST** /api/lists/ca0a7253-3ef3-4cc4-b868-0214e8d46bbd/items

  - creates a new item for the given list
  - returns link to the item

- **GET** /api/lists/ca0a7253-3ef3-4cc4-b868-0214e8d46bbd/items/09626d8a-bcc1-4fd7-b885-e92696cf9a2b

  - provides information about item { Id, Name, CreatedDate, Completed }
  - link to PUT the new state of the item
  - link to DELETE the item

- **PUT** /api/lists/ca0a7253-3ef3-4cc4-b868-0214e8d46bbd/items/09626d8a-bcc1-4fd7-b885-e92696cf9a2b

  - updates the state of the item

- **DELETE** /api/lists/ca0a7253-3ef3-4cc4-b868-0214e8d46bbd/items/09626d8a-bcc1-4fd7-b885-e92696cf9a2b

  - deletes the item from the list

  ​

  ​

  ​