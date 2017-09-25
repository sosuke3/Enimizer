lorom

!ADD = "CLC : ADC"
!SUB = "SEC : SBC"
!BLT = "BCC"
!BGE = "BCS"

; org $1AFBBB ;Increases chance of getting enemies under random bush
; db $01, $0F, $0F, $0F, $0F, $0F, $0F, $12 
; db $0F, $01, $0F, $0F, $11, $0F, $0F, $03

org $068279
NOP #$0A
JSL sprite_bush_spawn
NOP ; we keep the branch 

org $0DBA71
GetRandomInt:

; org $408000 ;begining of the 3mb expanded - Skip 0x80(overworld) + 0x128 (dungeons)
; ;Enemizer Flags
; db #$01 ;408000 : 200000 ; Flags for the enemies under bushes
; db #$00 ;408001 : 200001
; db #$00 ;408002 : 200002
; db #$00 ;408003 : 200003
; db #$00 ;408004 : 200004
; db #$00 ;408005 : 200005
; db #$00 ;408006 : 200006
; db #$00 ;408007 : 200007
; db #$00 ;408008 : 200008
; db #$00 ;408009 : 200009
; db #$00 ;40800A : 20000A
; db #$00 ;40800B : 20000B
; db #$00 ;40800C : 20000C
; db #$00 ;40800D : 20000D
; db #$00 ;40800E : 20000E
; db #$00 ;40800F : 20000F
; db #$00 ;408010 : 200010
; db #$00 ;408011 : 200011
; db #$00 ;408012 : 200012
; db #$00 ;408013 : 200013
; db #$00 ;408014 : 200014
; db #$00 ;408015 : 200015
; db #$00 ;408016 : 200016
; db #$00 ;408017 : 200017
; db #$00 ;408018 : 200018
; db #$00 ;408019 : 200019
; db #$00 ;40801A : 20001A
; db #$00 ;40801B : 20001B
; db #$00 ;40801C : 20001C
; db #$00 ;40801D : 20001D
; db #$00 ;40801E : 20001E
; db #$00 ;40801F : 20001F

org $408020 ;Skip 0x80(overworld) + 0x128 (dungeons)
sprite_bush_spawn_table:
{
    .sprites;SPRITE DATA TABLE GENERATED BY ENEMIZER
    skip #$1A8

    ;Old sprite table - Could be changed as well (for the item id 04)
    .random_sprites ; if item == 04
    db  #$00, #$D8, #$E3, #$D8
}

sprite_bush_spawn:
{
    STY $0D;restored code
    LDA $408000 ; That byte is the flag to activate random enemies under bush
    BNE .continue
    CPY.b #$04 : BNE .not_random_old
    JSL GetRandomInt : AND.b #$03 : !ADD.b #$13 : TAY
    .not_random_old
    LDA $81F3, Y;restored code 
    RTL
    .continue
    PHX : PHY ;save x,y just to be safe
    PHB : PHK : PLB ;setbank to 40

    CPY.b #$04 : BNE .not_random
    JSL GetRandomInt : AND.b #$03 : TAY
    LDA.w sprite_bush_spawn_table_random_sprites, Y 
    BRL .return

    .item_table
    db #$00, #$D9, #$3E, #$79, #$D9, #$DC, #$D8, #$DA, #$E4, #$E1, #$DC
    db #$D8, #$DF, #$E0, #$0B, #$42, #$D3, #$41, #$D4, #$D9, #$E3, #$D8

    .not_random

    CPY.b #$0F : BEQ .newSpriteSpawn
    CPY.b #$11 : BEQ .newSpriteSpawn
    CPY.b #$10 : BEQ .newSpriteSpawn
    CPY.b #$0E : BEQ .newSpriteSpawn

    LDA .item_table, Y
    BRA .return

    .newSpriteSpawn
    LDA $7E040A : TAY
    LDA sprite_bush_spawn_table_sprites, Y ;LDA 408000 + area id

    .return
    PLB;restore bank to where it was
    PLY : PLX ;restore x,y
    RTL
}