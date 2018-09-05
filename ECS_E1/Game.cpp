#include "Game.h"

Game::Game()
{
	mainWin.create(VideoMode(LARGEUR, HAUTEUR, 32), "ECS_Exemple");  // , Style::Titlebar); / , Style::FullScreen);
	view = mainWin.getDefaultView();

	mainWin.setVerticalSyncEnabled(true);
}

int Game::testTest()
{
	return 0;
}

int Game::run()
{
	if (!init())
	{
		return EXIT_FAILURE;
	}

	while (mainWin.isOpen())
	{
		getInputs();
		update();
		draw();
	}

	return EXIT_SUCCESS;
}

bool Game::init()
{
	return true;
}

void Game::getInputs()
{
	//On passe l'�v�nement en r�f�rence et celui-ci est charg� du dernier �v�nement re�u!
	while (mainWin.pollEvent(event))
	{
		//x sur la fen�tre
		if (event.type == Event::Closed)
		{
			mainWin.close();
		}
	}
}

void Game::update()
{

}

void Game::draw()
{
	mainWin.clear();

	mainWin.display();
}