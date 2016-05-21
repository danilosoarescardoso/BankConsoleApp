using System;

namespace BankConsoleApp
{
	public class ContaPremiumException : Exception
	{
		//EXCEPTIONS
		const string MENSAGEM_CONTA_NEGATIVA = "Não é possível abrir uma conta com valor ";
		//const é igual constante, não muda após ser setado

		public ContaPremiumException(): base()
		{
		}

		public ContaPremiumException(decimal valorInicial) : base(MENSAGEM_CONTA_NEGATIVA + valorInicial.ToString())
		{
		}
		public ContaPremiumException(string message, Exception inner) : base (message,inner)
		{
		}
	}
}