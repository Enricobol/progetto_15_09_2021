using System;
using System.Collections.Generic;
using System.Linq; // Una libreria speciale! per cercare dentro un IEnumerable con una LAMBDA!
using System.Text;
using System.Threading.Tasks;

namespace Scuola.Model
{
    public class Report
    {
        //PROPRIETA'
        public int NumEditions { get; set; }
        public decimal SumPrice { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal MedianPrice { get; set; }
        public decimal ModaPrice { get; set; }
        public int NumMaxStudents { get; set; }
        public int NumMinStudents { get; set; }

        //COSTRUTTORE
        public Report(int numEditions , decimal sumPrice , decimal averagePrice , decimal medianPrice , decimal modaPrice , int numMaxStudents , int numMinStudents)
        {
            NumEditions = numEditions;
            SumPrice = sumPrice;
            AveragePrice = averagePrice;
            MedianPrice = medianPrice;
            ModaPrice = modaPrice;
            NumMaxStudents = numMaxStudents;
            NumMinStudents = numMinStudents;
        }
        public Report()
        {

        }
        #region METODO StampReport : stampa a schermo il report
        //OUTPUT ->  n-edizioni | somma prezzi | media prezzi | mediana prezzi | moda prezzi | n-max studenti | n-min studenti
        public override string ToString()  //Sovrascrive il metodo virtuale dell'oggetto per stampare quello che vogliamo
        {
            return $"id: {NumEditions} | Somma: {SumPrice} | Media: {AveragePrice} | Mediana: {MedianPrice} | Moda: {ModaPrice} | Studenti max: {NumMaxStudents}| min: {NumMinStudents}"; //Non è una stringa normale con $, ma posso ficcarci dentro le variabili
        }
        #endregion
    }
}