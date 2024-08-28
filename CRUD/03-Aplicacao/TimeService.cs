﻿using CRUD.Entidades;
using CRUD.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Aplicacao
{
    public class TimeService
    {
        public SimuladorBD bd { get; set; }
        public TimeRepository repository { get; set; }

        public TimeService(SimuladorBD bdPreenchido)
        {
            bd = bdPreenchido;
            repository = new TimeRepository(bd);
        }

        public void Adicionar(Time time)
        {
            repository.Adicionar(time);
        }

        public void Remover(int id)
        {           
            repository.Remover(id);
        }

        public List<Time> Listar()
        {
            return repository.Listar();
        }

        public Time BuscarTimePorId(int id)
        {
           return repository.BuscarPorId(id);
        }
        public void Editar(int id, Time time)
        {
            repository.Editar(id, time.Nome, time.AnoCriacao);
        }
    }
}
