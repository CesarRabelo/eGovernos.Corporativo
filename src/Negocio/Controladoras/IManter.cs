namespace Negocio
{
    public interface IManter
    {
        System.Data.DataTable Consultar(System.Collections.Generic.Dictionary<string, object> filtros, string direcao);
        Pro.Dal.CrudActionTypes Excluir();
        void PrepararInclusao();
        Pro.Dal.CrudActionTypes Salvar(System.Collections.Generic.Dictionary<string, object> valores);
        System.Collections.Generic.Dictionary<string, object> Selecionar(int codigo);
        System.Data.DataTable Consultar(System.Collections.Generic.Dictionary<string, object> filtros, string direcao, string colunaSort);
    }
}