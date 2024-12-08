using CapaNegocio;
using System;
namespace TrabajoFinal
{
     public partial class Login
    {
        private readonly  _businessLogic;

        public FormLogin()
        {
            InitializeComponent();
            _businessLogic = new BusinessLogic();
        }
    }
}

