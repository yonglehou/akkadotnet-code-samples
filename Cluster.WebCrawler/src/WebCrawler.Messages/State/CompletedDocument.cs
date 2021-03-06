﻿using System.Collections.Generic;
using System.Linq;
using Akka.Actor;
using WebCrawler.Service.State;

namespace WebCrawler.Messages.State
{
    /// <summary>
    /// Represents a downloaded <see cref="CrawlDocument"/>
    /// </summary>
    public class CompletedDocument
    {
        public CompletedDocument(CrawlDocument document, int numBytes, ActorRef completedBy)
        {
            CompletedBy = completedBy;
            NumBytes = numBytes;
            Document = document;
        }

        public CrawlDocument Document { get; private set; }

        public int NumBytes { get; private set; }

        public ActorRef CompletedBy { get; private set; }
    }

    /// <summary>
    /// Represents new <see cref="CrawlDocument"/>s discovered by a parsing operation
    /// </summary>
    public class DiscoveredDocuments
    {
        public DiscoveredDocuments(IList<CrawlDocument> documents, ActorRef discoveredBy)
        {
            DiscoveredBy = discoveredBy;
            Documents = documents;
        }

        public IList<CrawlDocument> Documents { get; private set; }

        public int HtmlDocs { get { return Documents.Count(x => !x.IsImage); } }

        public int Images { get { return Documents.Count(x => x.IsImage); } }

        public ActorRef DiscoveredBy { get; private set; }
    }
}
