using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickCompare.Application.Dto;
using QuickCompare.Domain.Entity;

namespace QuickCompare.Application.Interfaces
{
    public interface ICompararCelulares
    {
        ComparacaoResultadosDto Comparar(CelularEntity celA, CelularEntity celB);

    }
}