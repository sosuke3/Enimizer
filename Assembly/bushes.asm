; this is set inside randomizer application
; org $1AFBBB ;Increases chance of getting enemies under random bush
; db $01, $0F, $0F, $0F, $0F, $0F, $0F, $12 
; db $0F, $01, $0F, $0F, $11, $0F, $0F, $03

; sprite_bush_spawn_table:
; {
;     ; SPRITE DATA TABLE GENERATED BY ENEMIZER
;     .overworld
;     ; Skip 0x80(overworld) + 0x128 (dungeons)
;     skip #$80
;     .dungeons
;     skip #$128

;     ;Old sprite table - Could be changed as well (for the item id 04)
;     .random_sprites ; if item == 04
;     db  #$00, #$D8, #$E3, #$D8
; }

sprite_bush_spawn:
{
    STY $0D           ; restored code
    LDA !BUSHES_FLAG  ; That byte is the flag to activate random enemies under bush
    BNE .continue
    CPY.b #$04 : BNE .not_random_old
    JSL GetRandomInt : AND.b #$03 : !ADD.b #$13 : TAY
    
    .not_random_old
    LDA $81F3, Y;restored code 
    RTL

    .continue
    PHX : PHY       ; save x,y just to be safe
    PHB : PHK : PLB ; setbank to 40

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
    ;CPY.b #$0E : BEQ .newSpriteSpawn

    LDA .item_table, Y
    BRA .return

    .newSpriteSpawn
    LDA $7E040A : TAY                               ; load the area ID
    LDA $7EF3C5 : CMP.b #$03 : !BLT .dontGoPhase2   ; check if agahnim 1 is alive
    ; aga1 is dead
    LDA $7E040A : CMP.b #$40 : !BGE .dontGoPhase2   ; check if we are in DW, if so we can skip shifting table index
    !ADD #$90 : TAY                                 ; agahnim 1 is dead, so we need to go to the 2nd phase table for LW
    .dontGoPhase2
    LDA sprite_bush_spawn_table_overworld, Y ;LDA 408000 + area id

    .return
    PLB         ; restore bank to where it was
    PLY : PLX   ; restore x,y
    RTL
}