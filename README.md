BytecodeRunner
==============

Virtual Machine for run custom bytecode.

What Works:
        SET,//  0   SELECT OR CREATE DESTINATION                        - INDEX
        ADD,//  1   SUM DESTINATION VALUE WITH PARAMETER                - TYPE - PAR
        REM,//  2   SUBTRACT DESTINATION VALUE WITH PARAMETER           - TYPE - PAR
        MUL,//  3   MULTIPLY DESTINATION VALUE WITH PARAMETER    				- TYPE - PAR
        DIV,//  4   DIVIDE DESTINATION VALUE WITH PARAMETER             - TYPE - PAR
        MOV,//  5   MOVE PARAMETER TO DESTINATION SELECTED              - TYPE - PAR
        PRT,//  6   PRINT DESTINATION VALUE                             - INDEX
