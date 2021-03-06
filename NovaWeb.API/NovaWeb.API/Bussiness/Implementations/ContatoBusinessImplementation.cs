﻿using NovaWeb.API.Repository;
using NovaWeb.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NovaWeb.API.Bussiness.Implementations
{
    public class ContatoBusinessImplementation : IContatoBusiness
    {
        private readonly IContatoRepository _repository;

        public ContatoBusinessImplementation(IContatoRepository repository)
        {
            _repository = repository;
        }

        private static string ApenasNumeros(string str)
        {
            var apenasDigitos = new Regex(@"[^\d]");
            return apenasDigitos.Replace(str, "");
        }

        public Contato Create(Contato model)
        {
            // Permitir apenas caracteres numéricos
            foreach (var item in model.Telefones)
            {
                item.Numero = ApenasNumeros(item.Numero);
            }
            return _repository.Create(model);
        }

        public bool Delete(long id)
        {
            if (id < 1)
            {
                return false;
            }
            return _repository.Delete(id);
        }

        public List<Contato> FindAll()
        {
            return _repository.FindAll();
        }

        public Contato FindById(long id)
        {
            if (id < 1)
            {
                return null;
            }
            return _repository.FindById(id);
        }

        public Contato Update(Contato model)
        {
            // Permitir apenas caracteres numéricos
            foreach (var item in model.Telefones)
            {
                item.Numero = ApenasNumeros(item.Numero);
            }
            return _repository.Update(model);
        }
    }
}
