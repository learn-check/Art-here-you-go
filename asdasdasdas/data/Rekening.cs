using System;
using System.Collections.Generic;
using System.Text;

namespace data
{
    class Rekening
    {
        public double Saldo { get; private set; }

        public Rekening(double StartSaldo)
        {
            Saldo = StartSaldo;
        }

        public void Bijschrijven(double ruben)
        {
            Saldo += ruben;
        }

        public double Afschrijven(double hoeveel)
        {
            Saldo -= hoeveel;
            return hoeveel;
        }

        public void OverSchrijven(Rekening naarRekening, double bedrag)
        {
            var geld = Afschrijven(bedrag);

            naarRekening.Bijschrijven(bedrag);
        }
    }
}
