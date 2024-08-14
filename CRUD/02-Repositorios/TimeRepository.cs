﻿using CRUD.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repositorios
{
    public class TimeRepository
    {
        public SimuladorBD bd { get; set; }

        public TimeRepository(SimuladorBD bdPreenchido)
        {
            bd = bdPreenchido;
        }

        public void Adicionar(Time time)
        {
            bd.Times.Add(time);
        }
        public void Remover(Time time)
        {
            bd.Times.Remove(time);
        }
        public void Editar(int id, Time editTime)
        {
            Time timeDoBancoDados = BuscarPorId(id);

            timeDoBancoDados.Nome = editTime.Nome;
            timeDoBancoDados.AnoCriacao = editTime.AnoCriacao;
        }
        public List<Time> Listar()
        {
            return bd.Times.ToList();
        }
        public Time BuscarPorId(int id)
        {
            foreach (Time t in bd.Times)
            {
                if (id == t.Id)
                {
                    return t;
                }
            }
            return null;
        }
    }
}
