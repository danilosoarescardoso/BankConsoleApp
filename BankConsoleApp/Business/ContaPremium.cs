using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankConsoleApp;

namespace Bank.Business
{
	public class ContaPremium : ContaBancaria
	{
		public const decimal SALDO_MINIMO = 200;
		public const decimal TAXA_CHEQUE_ESPECIAL = 15;

		private ContaPremium() { }

		public ContaPremium(decimal _saldoInicial)
		{
			if (_saldoInicial >= SALDO_MINIMO) {
				Saldo += _saldoInicial;

				InserirExtrato ("C - " + _saldoInicial.ToString ());
			} else {
				//levantar excecao específica
				if (_saldoInicial < 200) {
					throw new ContaPremiumException (_saldoInicial);
				}
			}
		}

		public override bool Resgatar(decimal _valorResgate)
		{
			bool resgateSucesso = base.Resgatar(_valorResgate);

			if (resgateSucesso && Saldo < SALDO_MINIMO)
			{
				Saldo -= TAXA_CHEQUE_ESPECIAL;

				base.InserirExtrato("TX - -" + TAXA_CHEQUE_ESPECIAL.ToString());

				return false;
			}
			else
			{
				return resgateSucesso;
			}
		}
	}
}