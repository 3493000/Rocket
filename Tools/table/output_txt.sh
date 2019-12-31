WORKSPACE=$(cd `dirname $0`; pwd)
SOURCETABLEDIR=$WORKSPACE/../../Tables/Sources/
TABLERESDIR=$WORKSPACE/../../UnityProject/Rocket/Assets/StreamingAssets/config

cd $WORKSPACE
./convertxlsx -i $SOURCETABLEDIR -o $TABLERESDIR
