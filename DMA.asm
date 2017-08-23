!DISP_REG           = $2100 ; Screen Display Register
!VMAIN_REG          = $2115 ; Video Port Control Register
!VRAM_LOW_REG       = $2116 ; VRAM Address Registers (Low)
!VRAM_HIGH_REG      = $2117 ; VRAM Address Registers (High)
!VRAM_WRITE_REG     = #$18  ; VRAM Data Write Registers (Low) (you always store it to the dest register so no need for the actual address)
!VRAM_READ_REG      = #$39  ; VRAM Data Read Registers (Low) (you always store it to the "dest" register so no need for the actual address)

!DMA0_CONTROL_REG   = $4300 ; DMA Control Register - channel 0
!DMA0_DEST_REG      = $4301 ; DMA Destination Register
!DMA0_SRC_LOW_REG   = $4302 ; DMA Source Address Register (Low)
!DMA0_SRC_HIGH_REG  = $4303 ; DMA Source Address Register (High)
!DMA0_SRC_BANK_REG  = $4304 ; DMA Source Address Register (Bank)
!DMA0_SIZE_LOW_REG  = $4305 ; DMA Size Registers (Low)
!DMA0_SIZE_HIGH_REG = $4306 ; DMA Size Registers (Low)

!DMA_ENABLE_REG     = $420B ; DMA Enable Register

!FORCE_VBLANK       = "LDA.b #$80 : STA $2100" ; blank screen

macro DMA_FROM_ROM_TO_VRAM(VRAM_HIGH,VRAM_LOW,SRC_BANK,SRC_HIGH,SRC_LOW,LENGTH_HIGH,LENGTH_LOW)
    PHA
        ; --- preserve DMA registers ----------------------------------------------------
        LDA !DMA0_CONTROL_REG   : PHA
        LDA !DMA0_DEST_REG      : PHA
        LDA !DMA0_SRC_LOW_REG   : PHA
        LDA !DMA0_SRC_HIGH_REG  : PHA
        LDA !DMA0_SRC_BANK_REG  : PHA
        LDA !DMA0_SIZE_LOW_REG  : PHA
        LDA !DMA0_SIZE_HIGH_REG : PHA
		; -------------------------------------------------------------------------------
        ;STZ !DMA_ENABLE_REG

		LDA #$80   : STA !VMAIN_REG          ; increment after writing $2119

        ; write to vram at $<VRAM_HIGH><VRAM_LOW>
		LDA <VRAM_LOW>  : STA !VRAM_LOW_REG  ; Set VRAM destination address low byte
		LDA <VRAM_HIGH> : STA !VRAM_HIGH_REG ; Set VRAM destination address high byte
		
        ; Set DMA0 to write a word at a time. (low bit=1)
        ; Set DMA0 to copy TO video memory (high bit=0)
		LDA #$01
		STA !DMA0_CONTROL_REG

        ; Write to $2118 & $2119 - VRAM Data Write Registers (Low) & VRAM Data Write Registers (High)
        ; setting word write mode on DMA0_CONTROL_REG causes a write to $2118 and then $2119
        ; $21xx is assumed
		LDA !VRAM_WRITE_REG
		STA !DMA0_DEST_REG
		
		; Read from $<SRC_BANK>:<SRC_HIGH><SRC_LOW>.
		LDA <SRC_LOW>
		STA !DMA0_SRC_LOW_REG           ; set src address low byte
		LDA <SRC_HIGH>
		STA !DMA0_SRC_HIGH_REG          ; set src address high byte
		LDA <SRC_BANK>
		STA !DMA0_SRC_BANK_REG          ; set src address bank byte

		; total bytes to copy: #$<LENGTH_HIGH><LENGTH_LOW> bytes.
		LDA <LENGTH_LOW>  : STA !DMA0_SIZE_LOW_REG   ; length low byte
		LDA <LENGTH_HIGH> : STA !DMA0_SIZE_HIGH_REG   ; length high byte

		!FORCE_VBLANK           ; blank screen
        ; start DMA on channel 0
		LDA #$01                        ; channel select bitmask
		STA !DMA_ENABLE_REG
		
		; --- restore DMA registers -----------------------------------------------------
        PLA : STA !DMA0_SIZE_HIGH_REG
        PLA : STA !DMA0_SIZE_LOW_REG
        PLA : STA !DMA0_SRC_BANK_REG
        PLA : STA !DMA0_SRC_HIGH_REG
        PLA : STA !DMA0_SRC_LOW_REG
        PLA : STA !DMA0_DEST_REG
        PLA : STA !DMA0_CONTROL_REG
		; -------------------------------------------------------------------------------
    PLA
endmacro

;-------------------------------------------------------------------------------------------------------
; Copy from Video RAM to Working RAM
;-------------------------------------------------------------------------------------------------------
macro DMA_FROM_VRAM_TO_RAM(VRAM_HIGH,VRAM_LOW,DEST_BANK,DEST_HIGH,DEST_LOW,LENGTH_HIGH,LENGTH_LOW)
    PHA
        ; --- preserve DMA registers ----------------------------------------------------
        LDA !DMA0_CONTROL_REG   : PHA
        LDA !DMA0_DEST_REG      : PHA
        LDA !DMA0_SRC_LOW_REG   : PHA
        LDA !DMA0_SRC_HIGH_REG  : PHA
        LDA !DMA0_SRC_BANK_REG  : PHA
        LDA !DMA0_SIZE_LOW_REG  : PHA
        LDA !DMA0_SIZE_HIGH_REG : PHA
		; -------------------------------------------------------------------------------
        STZ !DMA_ENABLE_REG

		LDA #$80   : STA !VMAIN_REG          ; increment after reading $213A

        ; write to vram at $<VRAM_HIGH><VRAM_LOW>
		LDA <VRAM_LOW>  : STA !VRAM_LOW_REG  ; Set VRAM source address low byte
		LDA <VRAM_HIGH> : STA !VRAM_HIGH_REG ; Set VRAM source address high byte
		
        ; Set DMA0 to write a word at a time. (low bit=1)
        ; Set DMA0 to copy FROM video memory (high bit=1)
		LDA #$81
		STA !DMA0_CONTROL_REG

        ; Read from $2139 and $213A
        ; $21xx is assumed
		LDA !VRAM_READ_REG
		STA !DMA0_DEST_REG
		
		; Write to $<DEST_BANK>:<DEST_HIGH><DEST_LOW>.
		LDA <DEST_LOW>
		STA !DMA0_SRC_LOW_REG           ; set dest address low byte
		LDA <DEST_HIGH>
		STA !DMA0_SRC_HIGH_REG          ; set dest address high byte
		LDA <DEST_BANK>
		STA !DMA0_SRC_BANK_REG          ; set dest address bank byte

		; total bytes to copy: #$<LENGTH_HIGH><LENGTH_LOW> bytes.
		LDA <LENGTH_LOW>  : STA !DMA0_SIZE_LOW_REG   ; length low byte
		LDA <LENGTH_HIGH> : STA !DMA0_SIZE_HIGH_REG   ; length high byte

		!FORCE_VBLANK           ; blank screen

        ; see snes developer manual book 1 : pg 2-27-21
        ;LDA.b $2139 ; need dummy read because reasons, not sure if this is strictly necessary or if just the read from $213A to get the fetch/increment going
        ;LDA.b $213A ; need dummy read because reasons
        LDA.w $2139 ; need dummy read because reasons, not sure if this is strictly necessary or if just the read from $213A to get the fetch/increment going
        LDA.w $2139 ; let's do 2 for fun

        ; start DMA on channel 0
		LDA #$01                        ; channel select bitmask
		STA !DMA_ENABLE_REG
		
		; --- restore DMA registers -----------------------------------------------------
        PLA : STA !DMA0_SIZE_HIGH_REG
        PLA : STA !DMA0_SIZE_LOW_REG
        PLA : STA !DMA0_SRC_BANK_REG
        PLA : STA !DMA0_SRC_HIGH_REG
        PLA : STA !DMA0_SRC_LOW_REG
        PLA : STA !DMA0_DEST_REG
        PLA : STA !DMA0_CONTROL_REG
		; -------------------------------------------------------------------------------
    PLA
endmacro


; macro DMA_FROM_RAM_TO_VRAM(CHANNEL,VRAM_HIGH,VRAM_LOW,SRC_BANK,SRC_HIGH,SRC_LOW,LENGTH_HIGH,LENGTH_LOW)
;     PHA
;         !DMA_CONTROL_REG   = $43<CHANNEL>0 ; DMA Control Register - channel <CHANNEL>
;         !DMA_DEST_REG      = $43<CHANNEL>1 ; DMA Destination Register
;         !DMA_SRC_LOW_REG   = $43<CHANNEL>2 ; DMA Source Address Register (Low)
;         !DMA_SRC_HIGH_REG  = $43<CHANNEL>3 ; DMA Source Address Register (High)
;         !DMA_SRC_BANK_REG  = $43<CHANNEL>4 ; DMA Source Address Register (Bank)
;         !DMA_SIZE_LOW_REG  = $43<CHANNEL>5 ; DMA Size Registers (Low)
;         !DMA_SIZE_HIGH_REG = $43<CHANNEL>6 ; DMA Size Registers (Low)

;         ; --- preserve DMA registers ----------------------------------------------------
;         LDA !DMA_CONTROL_REG   : PHA
;         LDA !DMA_DEST_REG      : PHA
;         LDA !DMA_SRC_LOW_REG   : PHA
;         LDA !DMA_SRC_HIGH_REG  : PHA
;         LDA !DMA_SRC_BANK_REG  : PHA
;         LDA !DMA_SIZE_LOW_REG  : PHA
;         LDA !DMA_SIZE_HIGH_REG : PHA
; 		; -------------------------------------------------------------------------------

; 		;LDA.b #$80 : STA !DISP_REG          ; blank screen
; 		LDA #$80   : STA !VMAIN_REG          ; increment after writing $2119

;         ; write to vram at $<VRAM_HIGH><VRAM_LOW>
; 		LDA <VRAM_LOW>  : STA !VRAM_LOW_REG  ; Set VRAM destination address low byte
; 		LDA <VRAM_HIGH> : STA !VRAM_HIGH_REG ; Set VRAM destination address high byte
		
;         ; Set DMA0 to write a word at a time.
; 		LDA #$01        : STA !DMA_CONTROL_REG

;         ; Write to $2118 & $2119 - VRAM Data Write Registers (Low) & VRAM Data Write Registers (High)
;         ; setting word write mode on DMA0_CONTROL_REG causes a write to $2118 and then $2119
;         ; $21xx is assumed
; 		LDA #$18        : STA !DMA_DEST_REG

;         ; #$80 ??? 2180 is wram
;         ; $2181 : low address
;         ; $2182 : high address
;         ; $2182 : bank
;         ; can be used for read or write but I don't see how to use them for reading while writing to vram because #$18 is used for vram write
;         ; and you can'r write to rom so it doesn't make any sense


; 		; Read from $<SRC_BANK>:<SRC_HIGH><SRC_LOW>.
; 		LDA <SRC_LOW>  : STA !DMA_SRC_LOW_REG           ; set src address low byte
; 		LDA <SRC_HIGH> : STA !DMA_SRC_HIGH_REG          ; set src address high byte
; 		LDA <SRC_BANK> : STA !DMA_SRC_BANK_REG          ; set src address bank byte

; 		; total bytes to copy: #$<LENGTH_HIGH><LENGTH_LOW> bytes.
; 		LDA <LENGTH_LOW>  : STA $4305   ; length low byte
; 		LDA <LENGTH_HIGH> : STA $4306   ; length high byte

; 		!FORCE_VBLANK           ; blank screen

;         ; start DMA on channel 0
;         ; this doesn't assemble correctly. which sucks
; 		;LDA #$01<<<CHANNEL>                        ; channel select bitmask
; 		LDA #$01                        ; channel select bitmask
; 		STA !DMA_ENABLE_REG
		
; 		; --- restore DMA registers -----------------------------------------------------
;         PLA : STA !DMA_SIZE_HIGH_REG
;         PLA : STA !DMA_SIZE_LOW_REG
;         PLA : STA !DMA_SRC_BANK_REG
;         PLA : STA !DMA_SRC_HIGH_REG
;         PLA : STA !DMA_SRC_LOW_REG
;         PLA : STA !DMA_DEST_REG
;         PLA : STA !DMA_CONTROL_REG
; 		; -------------------------------------------------------------------------------
;     PLA
; endmacro
