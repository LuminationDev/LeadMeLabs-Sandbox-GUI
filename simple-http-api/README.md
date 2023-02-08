# simple-http-api
A simple http service to receive commands and pass them on to a client experience running a pipe server

Receives commands via the following route format:
http://localhost:3000/target/kangaroo012/command/throw

- kangaroo012 being the object/target of the action
- throw being the action itself

To get going:
- check out the repo
- change to cd .\simple-http-api\
- npm install
- node app.js

Then you can make calls as above