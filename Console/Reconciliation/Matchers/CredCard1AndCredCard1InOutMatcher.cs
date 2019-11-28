using ConsoleCatchall.Console.Reconciliation.Loaders;
using ConsoleCatchall.Console.Reconciliation.Records;
using Interfaces;
using Interfaces.DTOs;

namespace ConsoleCatchall.Console.Reconciliation.Matchers
{
    internal class CredCard1AndCredCard1InOutMatcher : IMatcher
    {
        private readonly IInputOutput _input_output;
        private readonly ISpreadsheetRepoFactory _spreadsheet_factory;

        public CredCard1AndCredCard1InOutMatcher(IInputOutput input_output, ISpreadsheetRepoFactory spreadsheet_factory)
        {
            _input_output = input_output;
            _spreadsheet_factory = spreadsheet_factory;
        }

        public void Do_matching(FilePaths main_file_paths)
        {
            var loading_info = new CredCard1AndCredCard1InOutLoader().Loading_info();
            loading_info.File_paths = main_file_paths;
            var file_loader = new FileLoader(_input_output);
            ReconciliationInterface<CredCard1Record, CredCard1InOutRecord> reconciliation_interface
                = file_loader.Load_files_and_merge_data<CredCard1Record, CredCard1InOutRecord>(loading_info, _spreadsheet_factory, this);
            reconciliation_interface?.Do_the_matching();
        }

        public void Do_preliminary_stuff<TThirdPartyType, TOwnedType>(
                IReconciliator<TThirdPartyType, TOwnedType> reconciliator,
                IReconciliationInterface<TThirdPartyType, TOwnedType> reconciliation_interface)
            where TThirdPartyType : ICSVRecord, new()
            where TOwnedType : ICSVRecord, new()
        {
        }

        public void Finish()
        {
        }
    }
}