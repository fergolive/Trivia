using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;

//necesarios para el manejo de remoting y de los canales de comunicacion
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace ServicioRemoting
{
         //clase interna, ya que solo las clases de servicios especificos la utilizara
        internal class Servicio
        {
            //atributo que representa el canal que se usara para comunicarse mediante el protocolo TCP.
            //es de instancia, para que solo exista cuando ay un objeto servicio creado
            private TcpChannel unCanal;

            //clase coTdificada con patron SINGLETON
            private static Servicio _unicoServicio = null;

            //Constructor privadi que solo se puede utilizar para crear canal TCP de comunicacion.
            private Servicio()
            {
                unCanal = new TcpChannel();
                ChannelServices.RegisterChannel(unCanal, false);
                RemotingConfiguration.RegisterWellKnownClientType(typeof(Persistencia.FabricaPersistencia), "tcp://localhost:8989/FabricaPersistencia.remota");
            }

            public static void CreoServicio()
            {
                try
                {
                    if (_unicoServicio == null)
                        _unicoServicio = new Servicio();
                }
                catch(Exception es)
                {
                    throw new Exception(es.Message);
                }
            }
        }

}