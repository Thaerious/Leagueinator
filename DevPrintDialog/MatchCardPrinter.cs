
using System.Windows.Documents;

namespace MatchPrinter {

    public class MatchCardPaginator : DocumentPaginator {
        public override bool IsPageCountValid => throw new NotImplementedException();

        public override int PageCount => throw new NotImplementedException();

        public override System.Windows.Size PageSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override IDocumentPaginatorSource Source => throw new NotImplementedException();

        public override DocumentPage GetPage(int pageNumber) {
            throw new NotImplementedException();
        }
    }
}

