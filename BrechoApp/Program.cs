using System;
using System.Windows.Forms;
using BrechoApp.Data;

namespace BrechoApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // ============================================================
            //  GARANTE QUE TODAS AS TABELAS EXISTEM ANTES DE INICIAR O APP
            // ============================================================
            DatabaseInitializer.Initialize();

            // ============================================================
            //  CONFIGURAÇÕES PADRÃO DO WINDOWS FORMS (.NET 8)
            // ============================================================
            ApplicationConfiguration.Initialize();

            // ============================================================
            //  INICIA O FORMULÁRIO PRINCIPAL (MENU PRINCIPAL)
            // ============================================================
            Application.Run(new FormMenuPrincipal());
        }
    }
}