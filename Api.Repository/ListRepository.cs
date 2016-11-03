using Api.DataAccess.Mssql;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository {
    public class ListRepository {
        public IEnumerable<ListModel> listarTodos( ) {

            List<ListModel> lista = new List<ListModel>( );
            try {
               using( var DB = new checklistEntities( ) ) {
                    var query = from TBL in DB.tblList
                                orderby TBL.listPrioridade ascending, TBL.listLimitePrevisto ?? DateTime.MaxValue ascending
                                select TBL;
                    foreach( var item in query ) {
                        lista.Add( new ListModel {
                            listID = item.listID,
                            listDescricao = item.listDescricao,
                            listTitulo = item.listTitulo
                        } );
                    }
                }
                
            }
            catch( Exception e ) {
                throw e;
            }
            return lista;
        }
    }
}
