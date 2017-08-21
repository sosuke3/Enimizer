lorom

!ADD = "CLC : ADC"
!SUB = "SEC : SBC"
!BLT = "BCC"
!BGE = "BCS"

incsrc DMA.asm

; insert kholdstare shell gfx file
; pc file address = 0x123000
org $24B000
GFX_Kholdstare_Shell:
incbin shell.gfx
warnpc $24C001  ; should have written 0x1000 bytes and apparently we need to go 1 past that or it'll yell at us


;Gibdo key drop hardcoded in skullwoods to fix problems
;some bosses aredropping a key when there's a key drop avaiable in
;the previous room 

org $09DD74 ;Gibdo draw code (JSL Sprite_DrawShadowLong)
db #$00, #$00 ; Remove key drop in skull woods
org $1EBB37 ;Gibdo draw code (JSL Sprite_DrawShadowLong)
JSL gibdo_drop_key

;Move All Bosses Sprites in Top Left Quadrant
;Trinexx
org $09E5BA
db $00, $05, $07, $CB, $05, $07, $CC, $05, $07, $CD

;Armos
org $09E887
db $00, $05, $04, $53, $05, $07, $53, $05, $0A, $53
db $08, $0A, $53, $08, $07, $53, $08, $04, $53, $08, $E7, $19

;Kholdstare
org $09EA01
db $00, $05, $07, $A3, $05, $07, $A4, $05, $07, $A2

;Arrghus
org $09D997
db $00, $07, $07, $8C, $07, $07, $8D, $07, $07, $8D
db $07, $07, $8D, $07, $07, $8D, $07, $07, $8D, $07, $07, $8D
db $07, $07, $8D, $07, $07, $8D, $07, $07, $8D, $07, $07, $8D
db $07, $07, $8D, $07, $07, $8D, $07, $07, $8D

;Moldorm
org $09D9C3
db $00, $09, $09, $09

;Mothula (16 E7 07 (code for moving floor random) )
org $09DC31
db $00, $06, $08, $88, $FF

;Lanmolas
org $09DCCB
db $00, $07, $06, $54, $07, $09, $54, $09, $07, $54

;Helmasaure
org $09E049
db $00, $06, $07, $92

;Vitreous
org $09E457
db $00, $05, $07, $BD

;Blind
org $09E654
db $00, $05, $09, $CE


;On Room Transition -> Move Sprite depending on the room loaded
org $028979 ;  JSL Dungeon_ResetSprites ; REPLACE THAT (Sprite initialization) original jsl : $09C114 ; <-- 519 : Bank02.asm : JSL Dungeon_ResetSprites
JSL boss_move
org $028C16 ;  JSL Dungeon_ResetSprites ; REPLACE THAT (Sprite initialization) original jsl : $09C114
JSL boss_move
org $029338 ;  JSL Dungeon_ResetSprites ; REPLACE THAT (Sprite initialization) original jsl : $09C114
JSL boss_move
org $028256 ;  JSL Dungeon_ResetSprites ; REPLACE THAT (Sprite initialization) original jsl : $09C114
JSL boss_move

; water tiles removed in arrghus room
org $1FA15C 
db $FF, $FF, $FF, $FF, $F0, $FF, $61, $18, $FF, $FF

; Arrghus can stand on ground
org $0DB6BE
db $00


org $1E9518 ; Sprite_Kholdstare - sprite_kholdstare.asm(152)
JSL new_kholdstare_code ;Write new gfx in the vram

org $1DAD67 
JSL new_trinexx_code


org $249210
boss_move:
{
    ; TODO: should probably double check that we don't need to preserve registers (A,X)...

    ; Call what we overwrote and restore the dungeon_resetsprites
	JSL $09C114         ; JSL Dungeon_ResetSprites : Bank09.asm(822)

	LDA $A0             ; load room index (low byte)
	LDX $A1             ; 				  (high byte)

    LDY $A2             ; load previous room index (low byte)
;warnpc $0
    CMP #188 : BNE +    ; Room below boss room in TT
    LDA $A2 : CMP #172 : BNE + ; TT boss room
        ;Your Code Here
        JSL RestoreGfxBlock
    	;LDA $A0             ; load room index (low byte)
        BRL .return
    +
        ;%DMA_FROM_RAM_TO_VRAM(1,!VRAM_HIGH,!VRAM_LOW,!SAVE_VRAM_TO_BANK,!SAVE_VRAM_TO_HIGH,!SAVE_VRAM_TO_LOW,!LENGTH_HIGH,!LENGTH_LOW)


	CMP #7   : BNE +    ; Is is Hera Tower Boss Room
	CPX #$00 : BNE +
		BRL .move_to_middle
	+

	CMP #200 : BNE +    ; Is is Eastern Palace Boss Room
        JSL $09C44E     ; reset sprites twice in that room for some reasons (fix bug with kholdstare)
        JSL $09C114     ; Restore the dungeon_resetsprites
        BRL .move_to_bottom_right
	+

	CMP #41 : BNE +     ; Is is Skull Woods Boss Room
        ; Add moving floor sprite
        BRL .move_to_bottom_right
	+

	CMP #51 : BNE +     ; Is is Desert Palace Boss Room 
        JSL $09C44E     ; reset sprites twice in that room for some reasons (fix bug with kholdstare)
        JSL $09C114     ; Restore the dungeon_resetsprites
        BRL .move_to_bottom_left
	+

	CMP #90 : BNE +     ; Is is Palace of darkness Boss Room
        JSL $09C44E     ; reset sprites twice in that room for some reasons (fix bug with kholdstare)
        JSL $09C114     ; Restore the dungeon_resetsprites
        BRL .move_to_bottom_right
	+

	CMP #144 : BNE +    ; Is is Misery Mire Boss Room
        JSL $09C44E     ; reset sprites twice in that room for some reasons (fix bug with kholdstare)
        JSL $09C114     ; Restore the dungeon_resetsprites
        BRL .move_to_bottom_left
	+

	CMP #172 : BNE +    ; Is is Thieve Town Boss Room
                        ; IF MAIDEN IS NOT RESCUED -> DO NOTHING
                        ; IF MAIDEN IS ALREADY RESCUED -> spawn sprites normally
        JSL $09C44E     ; removes sprites in thieve town boss room
        JSL $09C114     ; Restore the dungeon_resetsprites
        BRL .move_to_bottom_right
	+

	CMP #6   : BNE +    ; Is is Swamp Palace Boss Room
	CPX #$00 : BNE +
        JSL $09C44E     ; reset sprites twice in that room for some reasons (fix bug with kholdstare)
        JSL $09C114     ; Restore the dungeon_resetsprites
        BRL .move_to_bottom_left
	+

	CMP #222 : BNE +    ; Is is Ice Palace Boss Room
    	BRL .move_to_top_right
	+

	CMP #164 : BNE +    ; Is is Turtle Rock Boss Room
    	BRL .move_to_bottom_left
	+

	CMP #28 : BNE +     ; Is is Gtower (Armos2) Boss Room
	CPX #$00 : BNE +
    	BRL .move_to_bottom_right
	+

	CMP #108 : BNE +    ; Is is Gtower (Lanmo2) Boss Room
        JSL $09C44E     ; reset sprites twice in that room for some reasons (fix bug with kholdstare)
        JSL $09C114     ; Restore the dungeon_resetsprites
        BRL .move_to_bottom_left
	+

	CMP #77 : BNE +     ; Is is Gtower (Moldorm2) Boss Room
        JSL $09C44E     ; reset sprites twice in that room for some reasons (fix bug with kholdstare)
        JSL $09C114     ; Restore the dungeon_resetsprites
        BRL .move_to_middle
	+

	BRL .return


	.move_to_middle
    ;load all sprite of that room and overlord
    LDX #$00
    .loop_middle
    LDA $0D10, X : !ADD #$68 : STA $0D10, X
    LDA $0D00, X : !ADD #$68 : STA $0D00, X
    INX : CPX #$10 : BNE .loop_middle
    LDX #$00
    .loop_middle2
    LDA $0B08, X : !ADD #$68 : STA $0B08, X
    LDA $0B18, X : !ADD #$68 : STA $0B18, X
    INX : CPX #$08 : BNE .loop_middle2
    BRL .return


	.move_to_top_right
    LDX #$00
    .loop_top_right
    LDA $0D20, X : !ADD #$00 : STA $0D20, X
    LDA $0D30, X : !ADD #$01 : STA $0D30, X
    INX : CPX #$10 : BNE .loop_top_right
    LDX #$00
    .loop_top_right2
    LDA $0B10, X : !ADD #$01 : STA $0B10, X
    LDA $0B20, X : !ADD #$00 : STA $0B20, X
    INX : CPX #$08 : BNE .loop_top_right2
    BRL .return


	.move_to_bottom_right
    LDX #$00
    .loop_bottom_right
    LDA $0D20, X : !ADD #$01 : STA $0D20, X
    LDA $0D30, X : !ADD #$01 : STA $0D30, X
    INX : CPX #$10 : BNE .loop_bottom_right
    LDX #$00
    .loop_bottom_right2
    LDA $0B10, X : !ADD #$01 : STA $0B10, X
    LDA $0B20, X : !ADD #$01 : STA $0B20, X
    INX : CPX #$08 : BNE .loop_bottom_right2
    BRL .return


	.move_to_bottom_left
    LDX #$00
    .loop_bottom_left
    LDA $0D20, X : !ADD #$01 : STA $0D20, X
    LDA $0D30, X : !ADD #$00 : STA $0D30, X
    INX : CPX #$10 : BNE .loop_bottom_left
    LDX #$00
    .loop_bottom_left2
    LDA $0B10, X : !ADD #$00 : STA $0B10, X
    LDA $0B20, X : !ADD #$01 : STA $0B20, X
    INX : CPX #$08 : BNE .loop_bottom_left2
    BRL .return


	.return
	RTL
}

gibdo_drop_key:
{
    LDA $A0 : CMP #$39 : BNE .no_key_drop       ; Check if the room id is skullwoods before boss
    LDA $0DD0, X : CMP #$09 : BNE .no_key_drop  ; Check if the sprite is alive
    LDA #$01 : STA $0CBA, X;set key
    .no_key_drop
    JSL $06DC5C ;Restore draw shadow
    RTL
}


!VRAM_HIGH = #$34 ; dest to write shell graphics / src to save previously loaded tiles into wram
!VRAM_LOW  = #$00

; 7F7667[0x6719] -   free ram
!SAVE_VRAM_TO_BANK = #$7F
!SAVE_VRAM_TO_HIGH = #$76
!SAVE_VRAM_TO_LOW  = #$67

!ROM_SRC_BANK = #$24
!ROM_SRC_HIGH = #$B0
!ROM_SRC_LOW  = #$00

!LENGTH_HIGH  = #$10
!LENGTH_LOW   = #$00


WriteGfxBlock:
{
    ;DMA_FROM_VRAM(VRAM_HIGH,VRAM_LOW,DEST_BANK,DEST_HIGH,DEST_LOW,LENGTH_HIGH,LENGTH_LOW)
    %DMA_FROM_VRAM_TO_RAM(!VRAM_HIGH,!VRAM_LOW,!SAVE_VRAM_TO_BANK,!SAVE_VRAM_TO_HIGH,!SAVE_VRAM_TO_LOW,!LENGTH_HIGH,!LENGTH_LOW)

    ;DMA_TO_VRAM(VRAM_HIGH,VRAM_LOW,SRC_BANK,SRC_HIGH,SRC_LOW,LENGTH_HIGH,LENGTH_LOW)
    %DMA_FROM_ROM_TO_VRAM(!VRAM_HIGH,!VRAM_LOW,!ROM_SRC_BANK,!ROM_SRC_HIGH,!ROM_SRC_LOW,!LENGTH_HIGH,!LENGTH_LOW)
    RTL
}

;warnpc $0
;$2494b2
RestoreGfxBlock:
{
    ;DMA_TO_VRAM(VRAM_HIGH,VRAM_LOW,SRC_BANK,SRC_HIGH,SRC_LOW,LENGTH_HIGH,LENGTH_LOW)
    ;%DMA_FROM_RAM_TO_VRAM(0,!VRAM_HIGH,!VRAM_LOW,!SAVE_VRAM_TO_BANK,!SAVE_VRAM_TO_HIGH,!SAVE_VRAM_TO_LOW,!LENGTH_HIGH,!LENGTH_LOW)
    %DMA_FROM_ROM_TO_VRAM(!VRAM_HIGH,!VRAM_LOW,!SAVE_VRAM_TO_BANK,!SAVE_VRAM_TO_HIGH,!SAVE_VRAM_TO_LOW,!LENGTH_HIGH,!LENGTH_LOW)

    ; LDX.w #$3400 : STX $2116
    ; LDA.b #$80 : STA $2115
    ; LDX.w #$1801 : STX $4300
    ; LDX.w #$7667 : STX $4302
    ; LDA.b #$7F   : STA $4304
    ; LDX.w #$1000 : STX $4305
    ; LDA.b #$01 : STA $420B
    ; LDA.b #$80 : STA $2100

    ; ; *$10B7-$10E2 JUMP LOCATION
    ; NMI_UpdateStarTiles:
    ; {
    ;     ; ( transfers 0x40 bytes from $7F0000 to vram $3ED0 (word)        
    ;     REP #$10
    ;     ; vram target address is $3ED0 (word)
    ;     LDX.w #$3ED0 : STX $2116
    ;     ; increment vram address on writes to $2119
    ;     LDA.b #$80 : STA $2115
    ;     ; base register is $2118, two registers write once ($2118 / $2119)
    ;     LDX.w #$1801 : STX $4300
    ;     ; source address is $7F0000
    ;     LDX.w #$0000 : STX $4302
    ;     LDA.b #$7F   : STA $4304
    ;     ; write 0x40 bytes
    ;     LDX.w #$0040 : STX $4305
    ;     ; transfer data on channel 1
    ;     LDA.b #$01 : STA $420B
    ;     REP #$10
    ;     RTS
    ; }

    RTL
}

new_kholdstare_code:
{
    LDA $0CBA : BNE .already_iced
    LDA #$01 : STA $0CBA
    JSL WriteGfxBlock;
    .already_iced
    JSL $0DD97F ; Bank0D.asm(1645) - address is different for JP rom!!!
    RTL
}

new_trinexx_code:
{
    LDA.b #$03 : STA $0DC0, X
    JSL WriteGfxBlock;
    RTL
}

warnpc $24B000  ; make sure we don't run into our shell graphics data
