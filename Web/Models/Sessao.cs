﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileTickets.Web.Models
{
    public class Sessao
    {
        public virtual int Id { get; set; }
        public virtual Espetaculo Espetaculo { get; set; }
        public virtual int TotalDeIngressos { get; set; }
        public virtual int IngressosReservados { get; set; }
        public virtual DateTime Inicio { get; set; }

        public virtual bool PodeReservar(int NumeroDeIngressos)
        {
            return IngressosDisponiveis >= NumeroDeIngressos ;
        }

        public virtual int IngressosDisponiveis
        {
            get
            {
                // faz a conta de total de ingressos menos ingressos reservados
                return TotalDeIngressos - IngressosReservados;
            }
        }

        public virtual void Reserva(int quantidade)
        {
            // soma quantidade na variavel ingressos reservados
            this.IngressosReservados += quantidade;
        }
    }
}
