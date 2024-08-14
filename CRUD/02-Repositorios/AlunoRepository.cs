﻿using CRUD._01_Entidades;
using CRUD.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD._02_Repositorios
{
    public class AlunoRepository
    {
        public SimuladorBD bd { get; set; }

        public AlunoRepository(SimuladorBD bdPreenchido)
        {
            bd = bdPreenchido;
        }

        public void Adicionar(Aluno aluno)
        {
            bd.Alunos.Add(aluno);
        }
        public void Remover(Aluno aluno)
        {
            bd.Alunos.Remove(aluno);
        }
        public void Editar(int id, Aluno editAluno)
        {
            Aluno alunoDoBancoDados = BuscarPorId(id);

            alunoDoBancoDados.Nome = editAluno.Nome;
            alunoDoBancoDados.Idade = editAluno.Idade;
            alunoDoBancoDados.Peso = editAluno.Peso;
        }
        public List<Aluno> Listar()
        {
            return bd.Alunos.ToList();
        }
        public Aluno BuscarPorId(int id)
        {
            foreach (Aluno a in bd.Alunos)
            {
                if (id == a.Id)
                {
                    return a;
                }
            }
            return null;
        }
    }
}
