﻿using Abp.Domain.Entities;
using GestorEventos.Servicios.Entidades;
using GestorEventos.Servicios.SQLUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Castle.MicroKernel.ModelBuilder.Descriptors.InterceptorDescriptor;

namespace GestorEventos.Servicios.Servicios
{
    public class ServiciosService : Service<Servicio>
    {
        public const string SQL_GetAll = "SELECT Servicios.* FROM EventosServicios INNER JOIN Servicios ON Servicios.idServicio = EventosServicios.IdServicio WHERE EventosServicios.IdEvento = {0}";

        public IEnumerable<Servicio>? GetServiciosByIdEvento(int idEvento)
        {

            using (var db = SQLConnect.New())
            {
                return db.Query<Servicio>(string.Format(SQL_GetAll, idEvento));
            }
        }
    }
}