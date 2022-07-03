import random

mix = {'RR':'1', 'RP':'2', 'RS':'3', 'PR':'4', 'PP':'5', 'PS':'6', 'SR':'7', 'SP':'8', 'SS':'9'}
rot = {'R':'P', 'P':'S', 'S':'R'}

length = 0
DNA = [""] * 3
meta = [random.choice("RPS")] * 18
skor = [0] * 18
output = random.choice("RPS")

while True:
    hand = input()
    if length:
        for i in range(3):
            skor[i] = 0.9 * skor[i] + (hand == meta[i]) - (hand == rot[rot[meta[i]]])
    length += 1
    DNA[0] += hand
    DNA[1] += output
    DNA[2] += mix[hand + output]
    for i in range(3):
        j = min(11, length)
        k = -1
        while j > 1 and k < 0:
                j -= 1
                k = DNA[i].rfind(DNA[i][-j:], 0, -1)
        meta[2 * i]=DNA[0][j + k]
        meta[2 * i + 1]=rot[DNA[1][j + k]]
    for i in range(6, 18):
        meta[i] = rot[meta[i - 6]]
    output = rot[meta[skor.index(max(skor))]]
    print(output)