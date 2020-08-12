#include <string>
#include <iostream>
#include "md5.h"


using namespace std;

int main()
{
	bool inicio = true;
	string comando;
	cout <<md5("hola")<< "\n\n";
    cout << "Bienvenido a GOT\n\n";
    while (inicio) {
		cout <<"Dijite su comando :" <<endl;
		getline(cin ,comando);
		if (comando.substr(0,4) == "got ") {
			if (comando.substr(4,4)== "exit"){
				inicio = false;
			}
			else if (comando.substr(4, 5) == "init ") {
				//funcion de init 
				cout << comando.substr(9) << endl; 
			}
			else if (comando.substr(4, 4) == "help") {
				cout << "Bienvenidos a la ayuda de GOT\n\n"
					<< "got init <name>\n"
					<< "Instancia un nuevo repositorio en el servidor y lo identifica con el nombre indicado por <name>.\n\n"
					<< "got add [-A] [name]\n"
					<< "Permite agregar todos los archivos que no esten registrados o que tengan nuevos cambios al repositorio. Puede usar -A para registrar todos los archivos o poner nombre para registrar solo uno.\n\n"
					<< "got commit <mensaje>\n"
					<< "Envia los archivos agregados y pendientes de commit al servidor. Se debe especificar un mensaje.\n\n"
					<< "got  status <file>\n"
					<< "Este comando en caso de no especificar archivo nos va a mostrar cuales archivos han sido cambiados, agregados o eliminados de acuerdo con el commit anterior.Se puede poner nombre para ver todo el historial del archivo.\n\n"
					<< "got rollback <file> <commit>\n"
					<< "Permite regresar un archivo en el tiempo a un commit especifico. \n\n"
					<< "got reset <file>\n"
					<< "Deshace cambios locales para un archivo y lo regresa al ultimo commit.\n\n"
					<< "got sync <file>\n"
					<< "Recupera los cambios para un archivo en el servidor y lo sincroniza con el archivo en el cliente. \n\n"
					<< "got exit\n"
					<< "Termina got\n\n"
						
					
					<< endl;

			}
			else if (comando.substr(4, 4) == "add ") {
				string aux = comando.substr(8);
				if (aux == "-A") {
					cout << "algo" <<endl;
				}
				else {
					cout << aux << endl;
				}
			}

			else if (comando.substr(4, 7) == "commit ") {
				//funcion de commit
				cout << comando.substr(11) << endl;

			}
			else if (comando.substr(4, 7) == "status ") {
				//funcion de status all
				cout << comando.substr(11) << endl;
			}
			else if (comando.substr(4, 6) == "status") {
				//funcion de status
	
			}
			else if (comando.substr(4, 9) == "rollback ") {
				string aux = comando.substr(13);
				for (int i = 0; i < aux.length(); i++) {
					if (aux.substr(i, 1) == " ") {
						cout << "File " << aux.substr(0,i) << endl;
						cout << "Commit " << aux.substr(i+1) << endl;
						break;
					}
				}

			}
			else if (comando.substr(4, 6) == "reset ") {
				//funcion de reset
				cout << comando.substr(10) << endl;
			}
			else if (comando.substr(4, 5) == "sync ") {
				//funcion de sync
				cout << comando.substr(9) << endl;
			}
			else {
				cout << "GOT no cuenta con este comando" << endl;
			}
		}
		else {
			cout << "No se acepta ese comando" << endl;
		}
	}
}
