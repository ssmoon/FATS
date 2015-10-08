declare @ids varchar(200)
set @ids = '(''10-1'', ''10-2'', ''11-1'', ''11-2'', ''12-1'', ''12-2'', ''12-3'', ''13-1'', ''13-2'', ''13-3'')'
exec ('Delete from TemplateRoutine Where Row_ID in ' + @ids)
exec ('Delete from TemplateNode Where RoutineID in ' + @ids)
exec ('Delete from BankAcceptBill Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from BankDraft Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from CashJournal Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from CollectAccept Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from CustomerLedger Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from IndividualSaving Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from DetailedLedger Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from EntrustBankPayment Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from EntrustCorpPayment Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from GeneralLedger Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from MoneyRemittance Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from RoutineGroup Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from SubjectItem Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from OuterSubject Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from TransferCheck Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from TeachingNode Where RoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from TeachingRoutine Where TmpRoutineID in ' + @ids)



CREATE PROCEDURE DelTestRoutine 
	@ids varchar(200)
as
begin
exec ('Delete from TemplateRoutine Where Row_ID in ' + @ids)
exec ('Delete from TemplateNode Where RoutineID in ' + @ids)
exec ('Delete from BankAcceptBill Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from BankDraft Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from CashJournal Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from CollectAccept Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from CustomerLedger Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from IndividualSaving Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from DetailedLedger Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from EntrustBankPayment Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from EntrustCorpPayment Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from GeneralLedger Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from MoneyRemittance Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from RoutineGroup Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from SubjectItem Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from OuterSubject Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from TransferCheck Where TchRoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from TeachingNode Where RoutineID in (Select Row_ID From TeachingRoutine Where TmpRoutineID in ' + @ids + ')')
exec ('Delete from TeachingRoutine Where TmpRoutineID in ' + @ids)

end