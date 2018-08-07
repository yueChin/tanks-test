using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FactoryManager{

    private static IAssetFactory mAssetFactory = null;
    private static ITankFactory mOneFactory = null;
    private static ITankFactory mTwoFactory = null;
    private static ITurretFactory mTurretFactory = null;
    private static IAttrFactory mAttrFactory = null;
    private static IBulletFactory mBulletFactory = null;
    private static IFiredBulletFactory mFiredBulletFactory = null;
    public static IAssetFactory assetFactory
    {
        get
        {
            if (mAssetFactory == null)
            {
                mAssetFactory = new ResourcesAssetProxyFactory();
            }
            return mAssetFactory;
        }
    }


    public static IAttrFactory attrFactory
    {
        get
        {
            if (mAttrFactory == null)
            {
                mAttrFactory = new AttrFactory();
            }
            return mAttrFactory;
        }
    }

    public static ITankFactory OneFactory
    {
        get
        {
            if (mOneFactory == null)
            {
                mOneFactory = new TankOneFactory();
            }
            return mOneFactory;
        }
    }

    public static ITankFactory TwoFactory
    {
        get
        {
            if (mTwoFactory == null)
            {
                mTwoFactory = new TankTwoFactory();
            }
            return mTwoFactory;
        }
    }

    public static ITurretFactory TurretFactory
    {
        get
        {
            if (mTurretFactory == null)
            {
                mTurretFactory = new TurretFactory();
            }
            return mTurretFactory;
        }
    }

    public static IBulletFactory BulletFactory
    {
        get
        {
            if(mBulletFactory == null)
            {
                mBulletFactory = new BulletFactory();
            }
            return mBulletFactory;
        }
    }

    public static IFiredBulletFactory FiredBulletFactory
    {
        get
        {
            if (mFiredBulletFactory == null)
            {
                mFiredBulletFactory = new FireBulletFactory();
            }
            return mFiredBulletFactory;
        }
    }

}
