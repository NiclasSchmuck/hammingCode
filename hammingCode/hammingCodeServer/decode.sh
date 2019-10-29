#!/bin/bash

arguments=0
declare -a bitArray
indexBitErr=0
bitpos=0

init() {
  local x=$1
  for (( i=0 ; i < ${#x} ; i++ )); do bitArray[i]=${x:i:1}; done
}

if [ ${#@} -eq 1 ]
then
  arguments=1
  init $1
else
  init "00011110000"
fi

if [ ${#bitArray[@]} -ne 11 ]
then
echo "Please enter an String with the length of 11 chars."
exit 1
else

echo "you inserted the following arguments: " ${bitArray[@]}


for (( i=1; i<=${#bitArray[@]}; i++ ));
do
  if [ $((i & ((i - 1)))) -eq 0 ]
  then
    val=0
    for (( j=i; j <=${#bitArray[@]}; j++ ));
    do
      if [ $((((j >> bitpos)) & 1)) -eq 1 ]
      then
        val=$((val + bitArray[((j - 1))]))
      fi
    done
    val=$((val % 2))
    indexBitErr=$((indexBitErr + ((val * i))))
    ((bitpos++))
  else
    decoded+=(${bitArray[((i - 1))]})
  fi
done
if [ $indexBitErr -gt 0 ]
then
  echo "Found an error at Index: " $indexBitErr
  ((indexBitErr--))
  bitArray[indexBitErr]=$((((${bitArray[indexBitErr]} + 1)) % 2))
else
  echo "All is fine. No error detected. Goin' home"
fi

echo "Decoded: ${decoded[@]}"
fi