INSERT INTO TemplateNode (Row_ID, NodeName, Tag, NodeIndex, NodeType, RoutineID, GroupIdx, RequireRecord) VALUES ('T1_DebitTransferCheck_S11', '持票人开户行受理转帐支票', 'Intro', 1, 'CommonNode', 'T1_DebitTransferCheck', 1, 0);

INSERT INTO TemplateNode (Row_ID, NodeName, Tag, NodeIndex, NodeType, RoutineID, GroupIdx, RequireRecord) VALUES ('T1_DebitTransferCheck_S12', '制单', 'Step_Init1', 2, 'DebitTransferCheck', 'T1_DebitTransferCheck', 1, 1);

INSERT INTO TemplateNode (Row_ID, NodeName, Tag, NodeIndex, NodeType, RoutineID, GroupIdx, RequireRecord) VALUES ('T1_DebitTransferCheck_S13', '录入明细账', 'DetailedLedger_Init', 3, 'CommonNode', 'T1_DebitTransferCheck', 1, 2);

INSERT INTO TemplateNode (Row_ID, NodeName, Tag, NodeIndex, NodeType, RoutineID, GroupIdx, RequireRecord) VALUES ('T1_DebitTransferCheck_S14', '录入总账', 'GeneralLedger_Init', 4, 'CommonNode', 'T1_DebitTransferCheck', 1, 2);

INSERT INTO TemplateNode (Row_ID, NodeName, Tag, NodeIndex, NodeType, RoutineID, GroupIdx, RequireRecord) VALUES ('T1_DebitTransferCheck_S21', '出票人开户行办理转帐', 'Intro', 5, 'CommonNode', 'T1_DebitTransferCheck', 2, 0);

INSERT INTO TemplateNode (Row_ID, NodeName, Tag, NodeIndex, NodeType, RoutineID, GroupIdx, RequireRecord) VALUES ('T1_DebitTransferCheck_S22', '制单', 'Step_Init1', 6, 'DebitTransferCheck', 'T1_DebitTransferCheck', 2, 1);

INSERT INTO TemplateNode (Row_ID, NodeName, Tag, NodeIndex, NodeType, RoutineID, GroupIdx, RequireRecord) VALUES ('T1_DebitTransferCheck_S23', '录入明细账', 'DetailedLedger_Init', 7, 'CommonNode', 'T1_DebitTransferCheck', 2, 1);

INSERT INTO TemplateNode (Row_ID, NodeName, Tag, NodeIndex, NodeType, RoutineID, GroupIdx, RequireRecord) VALUES ('T1_DebitTransferCheck_S24', '录入分户账', 'CurstomerLedger_Init', 8, 'CommonNode', 'T1_DebitTransferCheck', 2, 1);

INSERT INTO TemplateNode (Row_ID, NodeName, Tag, NodeIndex, NodeType, RoutineID, GroupIdx, RequireRecord) VALUES ('T1_DebitTransferCheck_S25', '录入总账', 'GeneralLedger_Init', 9, 'CommonNode', 'T1_DebitTransferCheck', 2, 2);

INSERT INTO TemplateNode (Row_ID, NodeName, Tag, NodeIndex, NodeType, RoutineID, GroupIdx, RequireRecord) VALUES ('T1_DebitTransferCheck_S31', '持票人开户行办理转帐入户', 'Intro', 10, 'CommonNode', 'T1_DebitTransferCheck', 3, 0);

INSERT INTO TemplateNode (Row_ID, NodeName, Tag, NodeIndex, NodeType, RoutineID, GroupIdx, RequireRecord) VALUES ('T1_DebitTransferCheck_S32', '制单', 'Step_Init1', 11, 'DebitTransferCheck', 'T1_DebitTransferCheck', 3, 1);

INSERT INTO TemplateNode (Row_ID, NodeName, Tag, NodeIndex, NodeType, RoutineID, GroupIdx, RequireRecord) VALUES ('T1_DebitTransferCheck_S33', '录入明细账', 'DetailedLedger_Init', 12, 'CommonNode', 'T1_DebitTransferCheck', 3, 1);

INSERT INTO TemplateNode (Row_ID, NodeName, Tag, NodeIndex, NodeType, RoutineID, GroupIdx, RequireRecord) VALUES ('T1_DebitTransferCheck_S34', '录入分户账', 'CurstomerLedger_Init', 13, 'CommonNode', 'T1_DebitTransferCheck', 3, 1);

INSERT INTO TemplateNode (Row_ID, NodeName, Tag, NodeIndex, NodeType, RoutineID, GroupIdx, RequireRecord) VALUES ('T1_DebitTransferCheck_S35', '录入总账', 'GeneralLedger_Init', 14, 'CommonNode', 'T1_DebitTransferCheck', 3, 2);

