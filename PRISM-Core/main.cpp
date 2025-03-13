#include <QApplication>
#include <QMainWindow>
#include <QMenuBar>
#include <QMenu>
#include <QAction>

int main(int argc, char *argv[]) {
    QApplication app(argc, argv);
    QMainWindow mainWindow;

    mainWindow.setWindowTitle("PRISM-Core");
    mainWindow.resize(800, 600);

    // Creating a menu bar
    QMenuBar *menuBar = new QMenuBar(&mainWindow);

    // File menu
    QMenu *fileMenu = new QMenu("File", menuBar);
    QAction *exitAction = fileMenu->addAction("Exit");
    menuBar->addMenu(fileMenu);


    QObject::connect(exitAction, &QAction::triggered, &app, &QApplication::quit);

    mainWindow.setMenuBar(menuBar);
    mainWindow.show();

    return app.exec();
}
