let balls = [];
let strip = []
let seenBalls = [];
let balance;


$('document').ready(function () {
    fetchBalls();
    fetchTicketBallList();

    fetchBalance();
    addBalls();
    $('#gameOverText').prop ('hidden', true);

   
    
       
    if (seenBalls.length === 0) {
        $("#ballText").css(`font-size`, '20px');
        $("#ballText").text(`<-------- Click to Load Ball`);
    } else {
        $("#ballText").css(`font-size`, '300px');
    }





    $('#loadBall').mouseenter(function () {
        TweenMax.to("#calledBall", 1, { scale: 0.4 });
    });
    $('#loadBall').mouseleave(function () {
        TweenMax.to("#calledBall", 1, { scale: 1 });
    });

    $('#loadBall').click(function (e) {
        e.preventDefault();

        callBall();
        TweenMax.to("#calledBall", 2, { scale: 1.5 });
        TweenMax.to("#calledBall", 1, { scale: 1 });
    });

    $('#testButton').click(function (e) {
    window.location = "/Home/Index"
        
        let audio = document.getElementById('myAudio');

        audio.pause();

    })

});

function fetchBalance() {
    fetch("http://localhost:50641/api/values/GetBalance")
        .then(data => data.json(0).then(body => {
            //console.log(body);
            balance = body;
            $('#balanceText').text(balance);
        }))
        .catch(err => console.log(err))
    console.log("Balance fetched")

}

function animateGameOverText() {
    $('#gameOverDiv').css('animation', 'PopUp');
    $('#gameOverDiv').css('animation-duration', '1s');
    $('#gameOverDiv').css('animation-iteration-count', 'infinite');
    $('#gameOverDiv').css('animation-timing-function', 'linear');
    $('#gameOverDiv').css('animation-delay', '.3s');
}

function fetchBalls() {

    fetch("http://localhost:50641/api/values")
            .then(data => data.json(0).then(body => {
                //console.log(body);
                balls = body;
            }))
            .catch(err => console.log(err))
        console.log("seqeuence fetched")
    
}

function populateStrip() {

    for (let i = 0; i < strip.length; i++) {
        let ball = strip[i];
        
        let { TicketId, BallCol, BallNum, BallRow } = ball;

        BallRow = (BallRow % 3) + 1;

        let ballOnStrip = document.getElementById(`ball_${TicketId}_${BallRow}_${BallCol - 1}`);

        if (BallNum != 0) {
            ballOnStrip.innerText = BallNum;
        }

        
    }
}

function daubBall(calledBall) {
 
    
    let { TicketId, BallCol, BallRow, GameOver } = calledBall;

   
    BallRow = (BallRow % 3) + 1;

    $(`#ball_${TicketId}_${BallRow}_${BallCol - 1}`).css("background-color", "green");

    if (GameOver == 1) {
        //alert('ONE-LINE  WIN HIPPY!!!!!')

        $(`#ticketRow_${TicketId}_${BallRow}`).css('border', '2px solid yellow')
        $(`#ticketRow_${TicketId}_${BallRow}`).css('width', '409px')
        
    } else if (GameOver == 2) {
        //alert('TWO-LINE  WIN HIPPY!!!!!')
        $(`#ticketRow_${TicketId}_${BallRow}`).css('border', '2px solid yellow')
        $(`#ticketRow_${TicketId}_${BallRow}`).css('width', '409px')
    } else if (GameOver == 3) {
       // alert('Full House  WIN HIPPY!!!!!')

        let data = { winType: 3 };
        fetch("http://localhost:50641/api/values/PostBalance", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })

        let audio = document.getElementById('myAudio');
        
        audio.play();
            //$('#gameOverDiv').css('display', 'block');
            //$('#gameOverText').addClass('gameOver');
            //animateGameOverText();

        $('#testButton').prop('disabled', false)
        $('#loadBall').prop('disabled', true)
        
        

       

       // alert('FULL HOUSE  WIN HIPPY!!!!!')
    }
}

function fetchTicketBallList() {

    fetch("http://localhost:50641/api/values/getticketballlist")
        .then(data => data.json(0).then(body => {
           // console.log(body);
            strip = body;
            populateStrip();
        }))
       
        .catch(err => console.log(err))
    console.log("strip fetched")

}



function callBall() {
    let generatedRandomNumber = genNumber();
    let ballToDuab;
    fetch("http://localhost:50641/api/values", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(generatedRandomNumber)
    })
        .then(res => res.json(0).then(body => {
           // console.log(body);
            ballToDuab = body;
            seenBalls.push(ballToDuab);
            daubBall(ballToDuab)
            let counter = seenBalls.length % 91;
            $(`#${counter}`).text(`${generatedRandomNumber.BallNum}`);
            $("#ballText").css(`font-size`, '80px');
            $("#ballText").text(`${generatedRandomNumber.BallNum}`);
            TweenMax.to("#calledBall", 2, { scale: 1 });
            updateCalledBalls(counter);

            if (seenBalls.length > 89) {
                $("#loadBall").prop(`disabled`, true);
                $('#loadBall').text('No more balls to load');
                $('#ballText').text('All');
                $('#gameOverText').prop('hidden', false);
                animateGameOverText();
            }
        }))

    

}
function animateGameOverText() {

}

function updateCalledBalls(counter) {
    seenBalls.forEach(number => {
        $(`#${counter}`).css("background-color", "blue");
    });
}

function genNumber() {

    let randPos =0;
    let number = balls[randPos];

    balls.splice(randPos, 1);

    return number;
}






function addBalls() {
    let counter = 1;
    for (let i = 1; i < 10; i++) {
        $("#display-balls").append(`<div class='row' id=row${i}>`);
        for (let j = 1; j <= 10; j++) {
            $(`#row${i}`).append(`<div class='col'><button id=${counter} class="btn btn-danger display-ball">
            
        </button></div>`);
            counter += 1;
        }
    }
    
    for (let i = 1; i <= 6; i++) {
        $('#stripDiv').append(
            `
                    <div class=' mt-1 ticket' id=ticketId${i}>
                       
                    </div>
             `); 
    }

    for (let k = 1; k <= 6; k++) {
        generateRow(k);
        generateColumn(k);
    } 
    
}

function generateColumn(ticketId, rowId) {
    let row = "";
    for (let j = 0; j < 9; j++) {
       

        row += `<div style:margin-bottom:0px;">
                        <div class='ticketCol'><button id=ball_${ticketId}_${rowId}_${j} class="btn btn-danger " 
                        style="margin-right: 0;
                            height: 33px;
                            padding:1px;
                            width: 45px;

                            border-radius: 0px;
                            border: 1px solid #940202;
                            
                        ">
                        
                        </button>
                    </div>
                        </div><br>`
    }

    return row;
}

function generateRow(ticketId) {
    for (let k = 1; k <=3; k++) {
   
        let ticket1 = document.getElementById(`ticketId${ticketId}`);
        ticket1.innerHTML += "<div class=\" ml-1 mr-1\" id='ticketRow_" + ticketId + "_" + k + "'+ style=\"margin:0px; border: 0px solid black;position:relative; display:flex; align-self:flex-start;\" >" + generateColumn(ticketId, k) + "</div > ";
    }
}
