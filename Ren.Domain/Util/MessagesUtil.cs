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
        public static string InvalidProperty = "O campo {0} é inválido";
        public static string InvalidIdentifier = "O identificador informado é inválido";
        public static string NotFound = "{0} não encontrado(a)";
        public static string InvalidInputs = "Verifique se todos os campos estão corretos";

        // User messages.
        public static string UserInactive = "O usuário está inativo";
        public static string SuccessAuth = "Seja bem-vindo";
        public static string NotAllowed = "Ação não permitida para seu nível de acesso";

        // Value Objects.
        public static string StringMinLength = "A propriedade {0} deve ter no mínimo {1} caracteres";
        public static string StringMaxLength = "A propriedade {0} deve ter no máximo {1} caracteres";
        public static string DifferentValues = "O campo {0} é diferente do campo {1}";
    }
}