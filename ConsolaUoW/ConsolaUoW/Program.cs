using Entidades;
using GestorDB;
using System;
using UnitOfWork.SQLServer;

namespace ConsolaUoW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UnitOfWorkSQLServer uow = new UnitOfWorkSQLServer();
            GestorSQL gestorSQL = new GestorSQL(uow);
            Cliente cli = gestorSQL.GetCliente(1);
            Console.WriteLine("Hello World!");
        }
    }
}
