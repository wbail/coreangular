using System.Collections.Generic;

namespace Eventos.IO.Application.ViewModels
{
    public class StatesViewModel
    {
        public string Uf { get; set; }

        public string Name { get; set; }

        public static List<StatesViewModel> ListStates()
        {
            return new List<StatesViewModel>()
            {
                new StatesViewModel() { Uf = "AC", Name = "Acre" },
                new StatesViewModel() { Uf = "AL", Name = "Alagoas" },
                new StatesViewModel() { Uf = "AM", Name = "Amazonas" },
                new StatesViewModel() { Uf = "AP", Name = "Amapá" },
                new StatesViewModel() { Uf = "BA", Name = "Bahia" },
                new StatesViewModel() { Uf = "CE", Name = "Ceará" },
                new StatesViewModel() { Uf = "DF", Name = "Distrito Federal" },
                new StatesViewModel() { Uf = "ES", Name = "Espírito Santo" },
                new StatesViewModel() { Uf = "GO", Name = "Goiás" },
                new StatesViewModel() { Uf = "MA", Name = "Maranhão" },
                new StatesViewModel() { Uf = "MG", Name = "Minas Gerais" },
                new StatesViewModel() { Uf = "MS", Name = "Mato Grosso do Sul" },
                new StatesViewModel() { Uf = "MT", Name = "Mato Grosso" },
                new StatesViewModel() { Uf = "PA", Name = "Pará" },
                new StatesViewModel() { Uf = "PB", Name = "Paraíba" },
                new StatesViewModel() { Uf = "PE", Name = "Pernambuco" },
                new StatesViewModel() { Uf = "PI", Name = "Piauí" },
                new StatesViewModel() { Uf = "PR", Name = "Paraná" },
                new StatesViewModel() { Uf = "RJ", Name = "Rio de Janeiro" },
                new StatesViewModel() { Uf = "RN", Name = "Rio Grande do Norte" },
                new StatesViewModel() { Uf = "RO", Name = "Rondônia" },
                new StatesViewModel() { Uf = "RR", Name = "Roraima" },
                new StatesViewModel() { Uf = "RS", Name = "Rio Grande do Sul" },
                new StatesViewModel() { Uf = "SC", Name = "Santa Catarina" },
                new StatesViewModel() { Uf = "SE", Name = "Sergipe" },
                new StatesViewModel() { Uf = "SP", Name = "São Paulo" },
                new StatesViewModel() { Uf = "TO", Name = "Tocantins" }
            };
        }
    }
}
