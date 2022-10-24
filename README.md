# tv-show-tracker

## Requirements

.NET SDK 6.0+

## Run Locally

Clone the project

```bash
  git clone https://link-to-project
```

Go to the project directory 
```bash
  cd tv-show-tracker/src/Api
```
Start the server
```bash
  dotnet run
```

## API Reference
SwaggerUI can be accessed via the endpoint (e.g.)
``
https://localhost:7257/swagger
``

### Register new user
```http
  POST /user/register
```
```curl
curl -X 'POST' \
  'https://localhost:7257/user/register' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "userName": "John",
  "email": "John@gmail.com",
  "password": "Jo123hn!?"
}'
```
| Parameter | Type     | Example |
| :-------- | :------- | :---------------- |
| `userName` | `string` | John |
| `email` | `string` | John@gmail.com |
| `password` | `string` | Jo123hn!? |


### Login
```http
  POST  /user/register
```
```curl
curl -X 'POST' \
  'https://localhost:7257/user/login' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "email": "John@gmail.com",
  "password": "Jo123hn!?"
}'
```
| Parameter | Type     | Example |
| :-------- | :------- | :---------------- |
| `email` | `string` | John@gmail.com |
| `password` | `string` | Jo123hn!? |


### Show 
```http
  GET  /show
```
```curl
curl -X GET \
  'https://localhost:7257/show?pageNumber=1&pageSize=10' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer {{Token}}'
```
| Parameter | Type     |  Description | Example |
| :-------- | :------- | :------- | :---------------- |
| `pageNumber` | `int` | *optional* | 1 |
| `pageSize` | `int` | *optional* | 10 |
| `Authorization` | `JWT` | *retrieved from login response* | xxx.yyy.zzz |

### Get show by id 
```http
  GET  /show/3
```
```curl
curl -X 'GET' \
  'https://localhost:7257/show/3' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer {{Token}}'
```
| Parameter | Type     | Description | Example |
| :-------- | :------- | :------- | :---------------- |
| `id` | `int` | | 3 |
| `Authorization` | `JWT` | *retrieved from login response* | xxx.yyy.zzz |


### Register new show
```http
  POST  /show
```
```curl
curl -X 'POST' \
  'https://localhost:7257/show' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer {{Token}}' \
  -H 'Content-Type: application/json' \
  -d '{
  "name": "Star Trek: Discovery",
  "description": "Star Trek, one of the most iconic and influential global television...",
  "url": "https://www.episodate.com/tv-show/star-trek-cbs",
  "startDate": "2017-09-24",
  "endDate": null,
  "genres": "Drama,Adventure,Science-Fiction"
}'
```
| Parameter | Type     | Description | Example |
| :-------- | :------- | :------- | :--------- |
| `name` | `string` | | Star Trek: Discovery |
| `description` | `string` | | Star Trek, one of the most iconic and influential global television... |
| `url` | `string` | | https://www.episodate.com/tv-show/star-trek-cbs |
| `startDate` | `date` | *format: yyyy-mm-dd*| 2017-09-24 |
| `endDate` | `date` | **Nullable** -  *format: yyyy-mm-dd*| null |
| `genres` | `string` | *comma separeted values*| Drama,Adventure,Science-Fiction |
| `Authorization` | `JWT` | *retrieved from login response* | xxx.yyy.zzz |


### Remove show
```http
  DELETE /show/3
```
```curl
curl -X 'DELETE' \
  'https://localhost:7257/show/3' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer {{Token}}'
```
| Parameter | Type     | Description | Example |
| :-------- | :------- | :------- | :---------------- |
| `id` | `int` | | 3 |
| `Authorization` | `JWT` | *retrieved from login response* | xxx.yyy.zzz |
