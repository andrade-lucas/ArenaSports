namespace Ren.Domain.Util
{
    public static class MessagesUtil
    {
        // Generic messages.
        public static string CreatedSuccess = "Cadastro realizado com sucesso";
        public static string CreatedError = "Erro ao cadastrar registro";
        public static string EditedSuccess = "Registro modificado com sucesso";
        public static string EditedError = "Erro ao modificar registro";
        public static string DeletedSuccess = "Registro deletado com sucesso";
        public static string DeleteError = "Erro ao deletar registro";
        public static string InvalidDocument = "Número de documento inválido";
        public static string InvalidIdentifier = "O identificador informado é inválido";

        // User messages.
        public static string UserInactive = "O usuário está inativo";

        // Value Objects.
        public static string StringMinLength = "A propriedade {0} deve ter no mínimo {1} caracteres";
        public static string StringMaxLength = "A propriedade {0} deve ter no máximo {1} caracteres";
    }
}