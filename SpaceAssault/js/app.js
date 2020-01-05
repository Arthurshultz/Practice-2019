// A cross-browser requestAnimationFrame
// See https://hacks.mozilla.org/2011/08/animating-with-javascript-from-setinterval-to-requestanimationframe/
var requestAnimFrame = (function () {
    return window.requestAnimationFrame ||
        window.webkitRequestAnimationFrame ||
        window.mozRequestAnimationFrame ||
        window.oRequestAnimationFrame ||
        window.msRequestAnimationFrame ||
        function (callback) {
            window.setTimeout(callback, 1000 / 60);
        };
})();

// Create the canvas
var canvas = document.createElement("canvas");
var ctx = canvas.getContext("2d");
canvas.width = 512;
canvas.height = 480;
document.body.appendChild(canvas);

// The main game loop
var lastTime;
function main() {
    var now = Date.now();
    var dt = (now - lastTime) / 1000.0;

    update(dt);
    render();

    lastTime = now;
    requestAnimFrame(main);
};

function init() {
    terrainPattern = ctx.createPattern(resources.get('img/terrain.png'), 'repeat');

    document.getElementById('play-again').addEventListener('click', function () {
        reset();
    });

    reset();
    lastTime = Date.now();
    main();
}

resources.load([
    'img/sprites.png',
    'img/terrain.png'
]);
resources.onReady(init);

// Game state
var player = {
    pos: [0, 0],
    sprite: new Sprite('img/sprites.png', [0, 0], [39, 39])
};

var bullets = [];
var enemies = [];
var explosions = [];
var megaliths = []; // megaliths
var mana = []; // mana
var manaUse = [] // for anim
var field = []; // create field


var lastFire = Date.now();
var gameTime = 0;
var isGameOver;
var terrainPattern;

var score = 0;
var scoreEl = document.getElementById('score');

var manaScore = 0;
var manaScoreEl = document.getElementById('manaScore');

// Speed in pixels per second
var playerSpeed = 200;
var bulletSpeed = 500;
var enemySpeed = 100;

var level = 0;

// create field
function setField() {
    for (var i = 0; i < canvas.height - 50; i = i + 55) {
        for (var j = 0; j < canvas.width - 90; j = j + 55) {
            field.push({
                fieldPos: [i, j],
                isBusy: false,
            });
        }
    }
}

// select random free position
function RandElement() {
    var rnd = Math.floor(Math.random() * (field.length))

    if (field[rnd].isBusy == true) {
        for (let i = 0; i < field.length; i++) {
            if (field[i].isBusy == false) {
                field[i].isBusy = true;
                return field[i];
            }
        }
    }
    else {
        field[rnd].isBusy = true;
        return field[rnd];
    }
}

// add megaliths
function spawnMegaliths() {
    var random = Math.floor(Math.random() * (+5 - +2)) + +2;

    for (var i = 0; i <= random; i++) {
        pos = RandElement();

        megaliths.push({
            pos: [pos.fieldPos[0], pos.fieldPos[1]],
            sprite: new Sprite('img/sprites.png', [3, 213], [55, 53])
        });
    }
}

//add mana
function spawnMana(count) {
    for (var i = 0; i <= count; i++) {
        pos = RandElement();

        mana.push({
            pos: [pos.fieldPos[0], pos.fieldPos[1]],
            sprite: new Sprite('img/sprites.png', [12, 163], [50, 42], 2, [0, 1])
        });
    }
}


// Update game objects
function update(dt) {
    gameTime += dt;

    handleInput(dt);
    updateEntities(dt);

    // It gets harder over time by adding enemies using this
    // equation: 1-.993^gameTime
    if (Math.random() < 1 - Math.pow(.993, gameTime)) {
        enemies.push({
            pos: [canvas.width,
            Math.random() * (canvas.height - 39)],
            sprite: new Sprite('img/sprites.png', [0, 78], [80, 39],
                6, [0, 1, 2, 3, 2, 1])
        });
    }

    checkCollisions();

    scoreEl.innerHTML = score;
    manaScoreEl.innerHTML = manaScore;
};

function handleInput(dt) {
    if (input.isDown('DOWN') || input.isDown('s')) {
        player.pos[1] += playerSpeed * dt;
    }

    if (input.isDown('UP') || input.isDown('w')) {
        player.pos[1] -= playerSpeed * dt;
    }

    if (input.isDown('LEFT') || input.isDown('a')) {
        player.pos[0] -= playerSpeed * dt;
    }

    if (input.isDown('RIGHT') || input.isDown('d')) {
        player.pos[0] += playerSpeed * dt;
    }

    if (input.isDown('SPACE') &&
        !isGameOver &&
        Date.now() - lastFire > 100) {
        var x = player.pos[0] + player.sprite.size[0] / 2;
        var y = player.pos[1] + player.sprite.size[1] / 2;

        bullets.push({
            pos: [x, y],
            dir: 'forward',
            sprite: new Sprite('img/sprites.png', [0, 39], [18, 8])
        });
        bullets.push({
            pos: [x, y],
            dir: 'up',
            sprite: new Sprite('img/sprites.png', [0, 50], [9, 5])
        });
        bullets.push({
            pos: [x, y],
            dir: 'down',
            sprite: new Sprite('img/sprites.png', [0, 60], [9, 5])
        });

        lastFire = Date.now();
    }
}

function updateEntities(dt) {
    // Update the player sprite animation
    player.sprite.update(dt);

    // Update all the bullets
    for (var i = 0; i < bullets.length; i++) {
        var bullet = bullets[i];

        switch (bullet.dir) {
            case 'up': bullet.pos[1] -= bulletSpeed * dt; break;
            case 'down': bullet.pos[1] += bulletSpeed * dt; break;
            default:
                bullet.pos[0] += bulletSpeed * dt;
        }

        // Remove the bullet if it goes offscreen
        if (bullet.pos[1] < 0 || bullet.pos[1] > canvas.height ||
            bullet.pos[0] > canvas.width) {
            bullets.splice(i, 1);
            i--;
        }
    }

    // Update all the enemies
    for (var i = 0; i < enemies.length; i++) {
        enemies[i].pos[0] -= enemySpeed * dt;
        enemies[i].sprite.update(dt);

        // Remove if offscreen
        if (enemies[i].pos[0] + enemies[i].sprite.size[0] < 0) {
            enemies.splice(i, 1);
            i--;
        }
    }

    // Update all the explosions
    for (var i = 0; i < explosions.length; i++) {
        explosions[i].sprite.update(dt);

        // Remove if animation is done
        if (explosions[i].sprite.done) {
            explosions.splice(i, 1);
            i--;
        }
    }

    // Update all the mana
    for (var i = 0; i < mana.length; i++) {
        mana[i].sprite.update(dt);
    }

    for (var i = 0; i < manaUse.length; i++) {
        manaUse[i].sprite.update(dt);

        // Remove if animation is done
        if (manaUse[i].sprite.done) {
            manaUse.splice(i, 1);
            i--;
        }
    }
}

// Collisions
function collides(x, y, r, b, x2, y2, r2, b2) {
    return !(r <= x2 || x > r2 ||
        b <= y2 || y > b2);
}

function boxCollides(pos, size, pos2, size2) {
    return collides(pos[0], pos[1],
        pos[0] + size[0], pos[1] + size[1],
        pos2[0], pos2[1],
        pos2[0] + size2[0], pos2[1] + size2[1]);
}

function checkCollisions() {
    checkPlayerBounds();

    // Run collision detection for all enemies and bullets
    for (var i = 0; i < enemies.length; i++) {
        var pos = enemies[i].pos;
        var size = enemies[i].sprite.size;

        for (var j = 0; j < bullets.length; j++) {
            var pos2 = bullets[j].pos;
            var size2 = bullets[j].sprite.size;

            if (boxCollides(pos, size, pos2, size2)) {
                // Remove the enemy
                enemies.splice(i, 1);
                i--;

                // Add score
                score += 100;

                // Add an explosion
                explosions.push({
                    pos: pos,
                    sprite: new Sprite('img/sprites.png',
                        [0, 117],
                        [39, 39],
                        16,
                        [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12],
                        null,
                        true)
                });

                // Remove the bullet and stop this iteration
                bullets.splice(j, 1);
                break;
            }
        }

        if (boxCollides(pos, size, player.pos, player.sprite.size)) {
            gameOver();
        }
    }

    // megalits collision
    for (var k = 0; k < megaliths.length; k++) {
        var pos = megaliths[k].pos;
        var size = megaliths[k].sprite.size;

        // megaliths vs bulletsts
        for (var j = 0; j < bullets.length; j++) {
            var pos2 = bullets[j].pos;
            var size2 = bullets[j].sprite.size;

            if (boxCollides(pos, size, pos2, size2)) {

                bullets.splice(j, 1);
                break;
            }
        }

        // megalits vs player
        if (boxCollides(pos, size, player.pos, player.sprite.size)) {

            if (player.pos[1] < pos[1] - size[1] / 2) {
                player.pos[1] = pos[1] - player.sprite.size[1];
            }
            else if (player.pos[1] > pos[1] + size[1] / 2) {
                player.pos[1] = pos[1] + size[1];
            }
            else if (player.pos[0] < pos[0] - size[0] / 2) {
                player.pos[0] = pos[0] - player.sprite.size[0];
            }
            else if (player.pos[0] > pos[0] + size[0] / 2) {
                player.pos[0] = pos[0] + size[0];
            }

        }

        // megalits vs alien
        for (var j = 0; j < enemies.length; j++) {

            var pos2 = enemies[j].pos;
            var size2 = enemies[j].sprite.size;

            if (boxCollides(pos, size, pos2, size2)) {

                var y = pos[1] + size[1] / 2;
                var y2 = pos2[1] + size2[1] / 2;

                for (var i = 0; i < 3; i++) {
                    if (y2 > y) {
                        enemies[j].pos[1] += i;
                    }
                    else {
                        enemies[j].pos[1] -= i;
                    }
                }
                break;
            }
        }
    }

    // mana vs player
    for (var k = 0; k < mana.length; k++) {
        var pos = mana[k].pos;
        var size = mana[k].sprite.size;

        if (boxCollides(pos, size, player.pos, player.sprite.size)) {

            manaScore += 1;

            manaUse.push({
                pos: pos,
                sprite: new Sprite('img/sprites.png',
                    [0, 161],
                    [55, 53],
                    8,
                    [0, 1, 2, 3],
                    null,
                    true)
            });

            for (var i = 0; i < field.length; i++) {
                if (field[i].fieldPos[0] == pos[0] && field[i].fieldPos[1] == pos[1]) {
                    field[i].isBusy = false;
                }
            }

            mana.splice(k, 1);
            spawnMana(0);
            break;
        }
    }
}

function checkPlayerBounds() {
    // Check bounds
    if (player.pos[0] < 0) {
        player.pos[0] = 0;
    }
    else if (player.pos[0] > canvas.width - player.sprite.size[0]) {
        player.pos[0] = canvas.width - player.sprite.size[0];
    }

    if (player.pos[1] < 0) {
        player.pos[1] = 0;
    }
    else if (player.pos[1] > canvas.height - player.sprite.size[1]) {
        player.pos[1] = canvas.height - player.sprite.size[1];
    }
}

// Draw everything
function render() {
    ctx.fillStyle = terrainPattern;
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    // Render the player if the game isn't over
    if (!isGameOver) {
        renderEntity(player);
    }

    renderEntities(bullets);
    renderEntities(enemies);
    renderEntities(explosions);

    renderEntities(megaliths);
    renderEntities(mana);
    renderEntities(manaUse);


};

function renderEntities(list) {
    for (var i = 0; i < list.length; i++) {
        renderEntity(list[i]);
    }
}

function renderEntity(entity) {
    ctx.save();
    ctx.translate(entity.pos[0], entity.pos[1]);
    entity.sprite.render(ctx);
    ctx.restore();
}

// Game over
function gameOver() {
    document.getElementById('game-over').style.display = 'block';
    document.getElementById('game-over-overlay').style.display = 'block';
    isGameOver = true;
}

// Reset game to original state
function reset() {
    document.getElementById('game-over').style.display = 'none';
    document.getElementById('game-over-overlay').style.display = 'none';
    isGameOver = false;
    gameTime = 0;
    score = 0;

    manaScore = 0;

    enemies = [];
    bullets = [];

    megaliths = [];
    mana = [];
    manaUse = [];
    field = [];

    setField();

    player.pos = [55, 220]; //[55, canvas.height / 2];

    for (var i = 0; i < field.length; i++) {
        if (field[i].fieldPos[0] == player.pos[0] && field[i].fieldPos[1] == player.pos[1]) {
            field[i].isBusy = true;
        }
    }

    spawnMegaliths();
    spawnMana(Math.floor(Math.random() * (+12 - +4)) + +4);
}; 
