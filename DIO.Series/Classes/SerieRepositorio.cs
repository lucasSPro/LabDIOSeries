using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie =  new List<Serie>();
        void IRepositorio<Serie>.Atualiza(int id, Serie entidade)
        {
            listaSerie[id] =  entidade;
        }

        void IRepositorio<Serie>.Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        void IRepositorio<Serie>.Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        List<Serie> IRepositorio<Serie>.Lista()
        {
            return listaSerie;
        }

        int IRepositorio<Serie>.ProximoId()
        {
            return listaSerie.Count;
        }

        Serie IRepositorio<Serie>.RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}