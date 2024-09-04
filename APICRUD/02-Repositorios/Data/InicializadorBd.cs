using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;

namespace CRUD._02_Repositorios.Data;


// ICONFIGURATION => Interface que ajuda a pegar valores (parametros) da configuração do appsettings
//connection string serve para conectar no banco 


//mudar o appsettings mudar o nome do banco para o nome correto
//tirar connection string (inicializador)
//criar construtor e passar por parametro o iconfiguration 
//colocar o nome do banco por parâmetro
//se der erro no iconfiguration no repository faça => config.getconnectionstring (buscando connection String) 
//passa prametro no controller 

//iconfiguration vem da controller 
//tirar connection open
//comandos para criar tabela
//trocar using (BAIIXAR BIBLIOTECA NO NUGGETS)
//LEVAR CONNECTION STRING PARA APPSETTINGS
public static class InicializadorBd
{
    public static void Inicializar()
    {
        using var connection = new SQLiteConnection("Data Source=CRUD.db");
        {
            
            string commandoSQL = @"   
                 CREATE TABLE IF NOT EXISTS Times(
                 Id INTEGER PRIMARY KEY AUTOINCREMENT,
                 Nome TEXT NOT NULL,
                 AnoCriacao INTEGER NOT NULL
                );";

            commandoSQL += @"   
                 CREATE TABLE IF NOT EXISTS Alunos(
                 Id INTEGER PRIMARY KEY AUTOINCREMENT,
                 Nome TEXT NOT NULL,
                 Idade INTEGER NOT NULL,
                 Peso REAL NOT NULL
                );";

            commandoSQL += @"   
                 CREATE TABLE IF NOT EXISTS Alunos(
                 Id INTEGER PRIMARY KEY AUTOINCREMENT,
                 Nome TEXT NOT NULL,
                 Idade INTEGER NOT NULL,
                 Peso REAL NOT NULL
                );";


            connection.Execute(commandoSQL);
        }
    }
}
