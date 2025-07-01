using SplashKitSDK;
using static SplashKitSDK.SplashKit;

const string GAME_TIMER = "GameTimer";

const int SCREEN_WIDTH = 800;
const int SCREEN_HEIGHT = 600;
const int SPIDER_RADIUS = 25;
const int SPIDER_SPEED = 3;

const int FLY_RADIUS = 10;

// Set the spider in the center of the screen
int spiderX = SCREEN_WIDTH / 2;
int spiderY = SCREEN_HEIGHT / 2;

// Create the fly
int flyX = Rnd(SCREEN_WIDTH), flyY = Rnd(SCREEN_HEIGHT);
bool flyAppeared = false;
long appearAtTime = 1000 + Rnd(2000);
long escapeAtTime = 0;

OpenWindow("Fly Catch", SCREEN_WIDTH, SCREEN_HEIGHT);

CreateTimer(GAME_TIMER);
StartTimer(GAME_TIMER);

// The event loop
while (!QuitRequested())
{
  // Handle Input
  if (KeyDown(KeyCode.RightKey) && spiderX + SPIDER_RADIUS < SCREEN_WIDTH)
  {
    spiderX += SPIDER_SPEED;
  }
  if (KeyDown(KeyCode.LeftKey) && spiderX - SPIDER_RADIUS > 0)
  {
    spiderX -= SPIDER_SPEED;
  }

  if (KeyDown(KeyCode.DownKey) && spiderY + SPIDER_RADIUS < SCREEN_HEIGHT)
  {
    spiderY += SPIDER_SPEED;
  }
  if (KeyDown(KeyCode.UpKey) && spiderY - SPIDER_RADIUS > 0)
  {
    spiderY -= SPIDER_SPEED;
  }



  // Update the Game
  // Check if the fly should appear
  if (! flyAppeared && TimerTicks(GAME_TIMER) > appearAtTime)
  {
    // Make the fly appear
    flyAppeared = true;

    // Give it a new random position
    flyX = Rnd(SCREEN_WIDTH);
    flyY = Rnd(SCREEN_HEIGHT);
    
    // Set its escape time
    escapeAtTime = TimerTicks(GAME_TIMER) + 2000 + Rnd(5000);
  }
  else if (flyAppeared && TimerTicks(GAME_TIMER) > escapeAtTime)
  {
    flyAppeared = false;
    appearAtTime = TimerTicks(GAME_TIMER) + 1000 + Rnd(2000);
  }

  if (CirclesIntersect(spiderX, spiderY, SPIDER_RADIUS, flyX, flyY, FLY_RADIUS))
  {
    flyAppeared = false;
    appearAtTime = TimerTicks(GAME_TIMER) + 1000 + Rnd(2000);
  }

  // Draw the game
  ClearScreen(ColorWhite());
  // Draw the spider
  FillCircle(ColorBlack(), spiderX, spiderY, SPIDER_RADIUS);

  if (flyAppeared)
  {
    // Draw the fly
    FillCircle(ColorDarkGreen(), flyX, flyY, FLY_RADIUS);
  }

  // Show it to  the user
  RefreshScreen(60);

  // Get any new user interactions
  ProcessEvents();
}
