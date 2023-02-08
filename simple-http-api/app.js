const express = require('express')
const app = express()
const port = 3000

app.get('/target/:targetArg/command/:commandArg', (req, res) => {
    res.send("got: target=" + req.params.targetArg + ", command=" + req.params.commandArg);

    //send stuff to experience process named pipe server here
})

app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})