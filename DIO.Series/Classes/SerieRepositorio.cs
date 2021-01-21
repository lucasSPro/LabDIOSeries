using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie =  new List<Serie>();
        public void Atualiza(int id, Serie entidade)
        {
            listaSerie[id] =  entidade;
        }

        public bool Exclui(int id)
        {
            
             if(listaSerie[id] != null){
                listaSerie[id].Excluir();
                return true;
            }else{
                return false;
            }
        }

        public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            if(listaSerie[id] != null){
                return listaSerie[id];
            }else{
                return null;
            }
        }
    }
}