using System;

namespace TestRule
{
    public class Printer
    {
        private readonly static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public Printer()
        {

        }

        public void Print()
        {
            logger.Info("开始打印");
            logger.Info(@"<targets>
                            <target xsi: type = 'File'
                            name ='String'
                            layout = 'Layout'
                            header = 'Layout'
                            footer = 'Layout'
                            encoding = 'Encoding'
                            lineEnding = 'Enum'
                            archiveAboveSize = 'Long'
                            maxArchiveFiles = 'Integer'
                            maxArchiveDays = 'Integer'
                            archiveFileName = 'Layout'
                            archiveNumbering = 'Enum'
                            archiveDateFormat = 'String'
                            archiveEvery = 'Enum'
                            archiveOldFileOnStartup = 'Boolean'
                            archiveOldFileOnStartupAboveSize = 'Long'
                            replaceFileContentsOnEachWrite = 'Boolean'
                            fileAttributes = 'Enum'
                            fileName = 'Layout'
                            deleteOldFileOnStartup = 'Boolean'
                            enableFileDelete = 'Boolean'
                            createDirs = 'Boolean'
                            concurrentWrites = 'Boolean'
                            openFileFlushTimeout = 'Integer'
                            openFileCacheTimeout = 'Integer'
                            openFileCacheSize = 'Integer'
                            networkWrites = 'Boolean'
                            concurrentWriteAttemptDelay = 'Integer'
                            concurrentWriteAttempts = 'Integer'
                            bufferSize = 'Integer'
                            autoFlush = 'Boolean'
                            keepFileOpen = 'Boolean'
                            forceManaged = 'Boolean'
                            enableArchiveFileCompression = 'Boolean'
                            cleanupFileName = 'Boolean'
                            writeFooterOnArchivingOnly = 'Boolean'
                            writeBom = 'Boolean' />
                            </ targets >");
            logger.Info("结束打印");
        }
    }
}
