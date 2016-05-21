using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Business
{
	public class ContaBancaria
	{
		private List<string> _extrato = new List<string>();

		private decimal _saldo;
		public decimal Saldo
		{
			get { return this._saldo; }
			protected set
			{
				this._saldo = value;
			}
		}

		public ContaBancaria()
		{
			Saldo = 0;
		}

		public ContaBancaria(decimal _saldoInicial)
		{
			if (_saldoInicial >= 0)
			{
				Saldo = _saldoInicial;

				InserirExtrato("C - " + _saldoInicial.ToString());
			}
			else
			{
				//levantar exceção específica
				Saldo = 0;
			}
		}

		public void Depositar(decimal _valorDeposito)
		{
			// só é possível depositar um valor positivo
			if (_valorDeposito >= 0)
			{
				Saldo += _valorDeposito;

				InserirExtrato("C - " + _valorDeposito.ToString());
			}
		}

		public virtual bool Resgatar(decimal _valorResgate)
		{
			if (_valorResgate >= 0)
			{
				Saldo -= _valorResgate;
				InserirExtrato("D - " + _valorResgate.ToString());
				return true;
			}
			else
			{
				return false;
			}
		}

		protected void InserirExtrato(string _linhaExtrato)
		{
			_extrato.Add(_linhaExtrato);
		}

		public string ImprimirExtrato()
		{
			StringBuilder extrato = new StringBuilder();

			foreach (var linhaExtrato in _extrato)
			{
				extrato.AppendLine(linhaExtrato);
			}

			extrato.AppendLine("Saldo Total: " + Saldo.ToString());

			return extrato.ToString();
		}
	}
}